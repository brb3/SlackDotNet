using System;
using System.Collections.Generic;
using System.Net.WebSockets;
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
        private ILogger<SlackSocket> Logger { get; }
        private IHelloHandler HelloHandler { get; }
        private ISlashCommandHandler SlashCommandHandler { get; }
        private IDefaultHandler DefaultHandler { get; }

        /// <summary>
        /// This controls the maximum amount of sockets that can be open with Slack. Slack has a limit of 10
        /// simultaneous connections for an application.
        /// </summary>
        private int SocketLimit { get; } = 10;

        /// <summary>
        /// A collection of WebSocketClients and their connection status.
        /// </summary>
        private WebSocketWrapper[] WebSocketClients { get; set; } = Array.Empty<WebSocketWrapper>();

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
            foreach (var client in WebSocketClients)
            {
                client.Dispose();
            }
            GC.SuppressFinalize(this);
        }

        public async Task Connect(int activeConnections = 2)
        {
            if (activeConnections > SocketLimit)
            {
                Logger.LogWarning($"WebSocket connections are limited to {SocketLimit}.");
                activeConnections = SocketLimit;
            }

            Logger.LogInformation("Requesting WebSocket URL from Slack.");
            var wssUrl = await GetWssUrl();
            Logger.LogInformation("WebSocket URL requested successfully.");

            for (int i = 0; i < activeConnections; i++)
            {
                Logger.LogInformation($"Socket Connection {i} of {activeConnections}: Connecting to WebSocket.");
                try
                {
                    if (WebSocketClients[i] == null)
                    {
                        WebSocketClients[i] = new WebSocketWrapper();
                    } else if (WebSocketClients[i].Connected == true)
                    {
                        Logger.LogInformation($"Socket Connection {i} of {activeConnections}: Already established. Skipping.");
                        continue;
                    }
                    WebSocketClients[i].MessageHandler = (e) => Task.Run(() => HandleMessage(e.Data, e.WebSocket));
                    await WebSocketClients[i].ConnectAsync(wssUrl.ToString());
                    WebSocketClients[i].Connected = true;
                }
                catch (Exception e)
                {
                    throw new SlackSocketConnectionException($"Socket Connection {i} of {activeConnections}: Cannot connect to the WebSocket provided by Slack. See inner exception for more details.", e);
                }
                Logger.LogInformation($"Socket Connection {i} of {activeConnections}: WebSocket connection successfully established.");
            }
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

        public async Task HandleMessage(string message, WebSocket socket)
        {
            var socketMessage = JsonConvert.DeserializeObject<SlackWebSocketMessage>(message);

            if (MessageHasBeenHandled(socketMessage.EnvelopeId))
            {
                Logger.LogWarning($"A duplicate message has been received. Ignoring envelope ID {socketMessage.EnvelopeId}");
                return;
            }

            // After receiving a message from the WebSocket, we need to first ack the message to prevent resends if we won't be responding via the socket.
            if (!String.IsNullOrEmpty(socketMessage.EnvelopeId)
                && socketMessage.AcceptsResponsePayload == false)
            {
                var ack = new SlackWebSocketMessageResponse(socketMessage);
                await socket.SendStringAsync(ack.ToString());
            }

            // Find the appropriate handler
            // TODO: this can be done better, and still ack appropriately
            switch (socketMessage.Type)
            {
                case (SlackWebSocketMessageType.hello):
                    var helloMessage = JsonConvert.DeserializeObject<HelloMessage>(message);
                    await HelloHandler.Handle(helloMessage);
                    break;
                case (SlackWebSocketMessageType.slash_commands):
                    var slashCommandMessage = JsonConvert.DeserializeObject<SlashCommandMessage>(message);
                    var response = await SlashCommandHandler.Handle(slashCommandMessage);
                    await socket.SendStringAsync(response.ToString());
                    break;
                case (SlackWebSocketMessageType.interactive): // TODO
                case (SlackWebSocketMessageType.events_api): // TODO
                default:
                    await DefaultHandler.Handle(socketMessage);
                    break;
            }
        }
    }
}
