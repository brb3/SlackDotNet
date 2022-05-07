using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SlackDotNet.Enums;
using SlackDotNet.Exceptions;
using SlackDotNet.Handlers;
using SlackDotNet.Models;
using SlackDotNet.Models.Messages;
using SlackDotNet.Models.Responses;
using WebSocketExtensions;

namespace SlackDotNet
{
    public class SlackSocket : ISlackSocket, IDisposable
    {
        private SlackOptions Options { get; set; }
        private WebSocketClient WebSocketClient { get; set; } = new WebSocketClient();
        private ILogger<SlackSocket> Logger { get; }
        private IHelloHandler HelloHandler { get; }
        private ISlashCommandHandler SlashCommandHandler { get; }
        private IDefaultHandler DefaultHandler { get; }

        /// <summary>
        /// A list of envelope IDs and the time when they were received.
        ///
        /// This is used to make sure that we don't respond to a Message that's already been received.
        /// </summary>
        private readonly Dictionary<string, DateTime> MessageEnvelopeIds = new Dictionary<string, DateTime>();

        /// <summary>
        /// The age of the MessageEnvelopeIds cache. When checked, envelope IDs older than this will be discarded.
        /// </summary>
        private readonly TimeSpan CacheAge = new TimeSpan(1, 0, 0);

        public SlackSocket(
            IOptions<SlackOptions> options,
            ILogger<SlackSocket> logger,
            IDefaultHandler defaultHandler,
            IHelloHandler helloHandler,
            ISlashCommandHandler slashCommandHandler)
        {
            Options = options.Value;
            Logger = logger;
            HelloHandler = helloHandler;
            DefaultHandler = defaultHandler;
            SlashCommandHandler = slashCommandHandler;
        }

        public void Dispose()
        {
            WebSocketClient.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Connect()
        {
            Logger.LogInformation("Requesting WebSocket URL from Slack.");
            var wssUrl = await GetWssUrl();
            Logger.LogInformation("WebSocket URL requested successfully.");

            Logger.LogInformation("Connecting to WebSocket");
            try
            {
                WebSocketClient.MessageHandler = (e) => Task.Run(() => HandleMessage(e.Data));
                await WebSocketClient.ConnectAsync(wssUrl.ToString());
            }
            catch (Exception e)
            {
                throw new SlackSocketConnectionException("Cannot connect to the WebSocket provided by Slack. See inner exception for more details.", e);
            }
            Logger.LogInformation("WebSocket connection successfully established.");
        }

        public bool MessageHasBeenHandled(string envelopeId)
        {
            var exists = MessageEnvelopeIds.ContainsKey(envelopeId);
            var now = DateTime.Now;
            var nowMinusCacheAge = now - CacheAge;

            if (!exists)
            {
                MessageEnvelopeIds.Add(envelopeId, now);
            }

            foreach (var envelope in MessageEnvelopeIds)
            {
                if (DateTime.Compare(envelope.Value, nowMinusCacheAge) < 0)
                {
                    MessageEnvelopeIds.Remove(envelope.Key);
                }
            }

            return exists;
        }

        /// <summary>
        /// Gets the WSS URL to connect to from Slack.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="SlackSocketConnectionException"></exception>
        private async Task<Uri> GetWssUrl()
        {
            Connection response;
            try
            {
                response = await SlackApiEndpoints.AppConnectionsOpen
                    .WithHeader("Authorization", $"Bearer {Options.AppLevelToken}")
                    .PostAsync()
                    .ReceiveJson<Connection>();
            }
            catch (Exception e)
            {
                throw new SlackApiResponseException("Failed to get a WSS URL from the Slack API.", e);
            }

            if (!response.Ok)
            {
                throw new SlackApiResponseException("Slack refused to return a Socket URL.");
            }

            return response.Url;
        }

        public async Task HandleMessage(string message)
        {
            var socketMessage = JsonConvert.DeserializeObject<SlackWebSocketMessage>(message);

            if (MessageHasBeenHandled(socketMessage.EnvelopeId))
            {
                Logger.LogWarning($"A duplicate message has been received. Ignoring envelope ID {socketMessage.EnvelopeId}");
                return;
            }

            // After receiving a message from the WebSocket, we need to first ack the message to prevent resends if we won't be responding via the socket.
            var acceptsResponse = socketMessage.AcceptsResponsePayload;
            var response = new SlackWebSocketMessageResponse(socketMessage);
            if (!String.IsNullOrEmpty(socketMessage.EnvelopeId) && !acceptsResponse)
            {
                await WebSocketClient.SendStringAsync(response.ToString());
            }

            // Find the appropriate handler
            switch (socketMessage.Type)
            {
                case (SlackWebSocketMessageType.hello):
                    var helloMessage = JsonConvert.DeserializeObject<HelloMessage>(message);
                    await HelloHandler.Handle(helloMessage);
                    break;
                case (SlackWebSocketMessageType.slash_commands):
                    var slashCommandMessage = JsonConvert.DeserializeObject<SlashCommandMessage>(message);
                    response = await SlashCommandHandler.Handle(slashCommandMessage);
                    break;
                case (SlackWebSocketMessageType.interactive): // TODO
                case (SlackWebSocketMessageType.events_api): // TODO
                default:
                    await DefaultHandler.Handle(socketMessage);
                    break;
            }

            // If the handle accepts a response, we got a message back from the handler to send.
            if (acceptsResponse)
            {
                await WebSocketClient.SendStringAsync(response.ToString());
            }
        }
    }
}
