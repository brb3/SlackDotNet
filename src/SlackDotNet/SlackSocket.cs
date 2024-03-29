using System;
using System.Collections.Generic;
using System.Linq;
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
        private IEventsAPIHandler EventsAPIHandler { get; }
        private IDefaultHandler DefaultHandler { get; }

        /// <summary>
        /// This controls the maximum amount of sockets that can be open with Slack. Slack has a limit of 10
        /// simultaneous connections for an application.
        /// </summary>
        private int SocketLimit { get; } = 10;

        /// <summary>
        /// A collection of WebSocketClients and their connection status.
        /// </summary>
        private List<WebSocketWrapper> WebSocketClients { get; set; } = new List<WebSocketWrapper>();

        private Guid[] WebSocketIds { get; set; } = new Guid[10];

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
            ISlashCommandHandler slashCommandHandler,
            IEventsAPIHandler eventsAPIHandler)
        {
            Options = options.Value;
            Logger = logger;
            HelloHandler = helloHandler;
            DefaultHandler = defaultHandler;
            SlashCommandHandler = slashCommandHandler;
            EventsAPIHandler = eventsAPIHandler;
        }

        public void Dispose()
        {
            WebSocketClients.ForEach((c) => c.Dispose());
            GC.SuppressFinalize(this);
        }

        public async Task Connect(int activeConnections = 2)
        {
            if (activeConnections > SocketLimit)
            {
                Logger.LogWarning($"WebSocket connections are limited to {SocketLimit}.");
                activeConnections = SocketLimit;
            }

            for (int i = 0; i < activeConnections; i++)
            {
                var logPreamble = $"Socket Connection {i+1} of {activeConnections}: ";
                Logger.LogInformation($"{logPreamble}Requesting WebSocket URL from Slack.");
                var wssUrl = await GetWssUrl();
                Logger.LogInformation($"{logPreamble}WebSocket URL requested successfully.");

                Logger.LogInformation($"{logPreamble}Connecting to WebSocket.");

                try
                {
                    if (WebSocketClients.ElementAtOrDefault(i) == null)
                    {
                        WebSocketClients.Add(new WebSocketWrapper());
                    }
                    else if (WebSocketClients[i].Connected == true)
                    {
                        Logger.LogInformation($"{logPreamble}Already established. Skipping.");
                        continue;
                    }
                    WebSocketClients[i].MessageHandler = (e) => Task.Run(() => HandleMessage(e));
                    await WebSocketClients[i].ConnectAsync(wssUrl.ToString());
                    WebSocketClients[i].Connected = true;
                }
                catch (Exception e)
                {
                    throw new SlackSocketConnectionException($"{logPreamble}Cannot connect to the WebSocket provided by Slack. See inner exception for more details.", e);
                }
                Logger.LogInformation($"{logPreamble}WebSocket connection successfully established.");
            }
        }

        /// <summary>
        /// When a disconnect message is received for a socket connection, we have to rebuilt the connection.
        /// </summary>
        /// <param name="connectionId"></param>
        /// <returns></returns>
        private async Task RefreshConnection(Guid clientId)
        {
            Logger.LogInformation("Received a disconnect message.");
            var wssUrl = await GetWssUrl();
            var socketIndex = WebSocketClients.FindIndex((w) => w.ClientId == clientId);
            try
            {
                WebSocketClients[socketIndex].Connected = false;
                WebSocketClients[socketIndex].MessageHandler = (e) =>
                    Task.Run(() => HandleMessage(e));
                await WebSocketClients[socketIndex].ConnectAsync(wssUrl.ToString());
                WebSocketClients[socketIndex].Connected = true;
            }
            catch (Exception e)
            {
                throw new SlackSocketConnectionException($"Cannot connect to the WebSocket provided by Slack. See inner exception for more details.", e);
            }
            Logger.LogInformation($"WebSocket connection successfully reestablished.");
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

        public async Task HandleMessage(StringMessageReceivedEventArgs messageEvent)
        {
            var socketMessage = JsonConvert.DeserializeObject<SlackWebSocketMessage>(messageEvent.Data);

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
                Logger.LogInformation($"Acknowledging websocket message {socketMessage.EnvelopeId}");
                await messageEvent.WebSocket.SendStringAsync(response.ToString());
            }

            // Find the appropriate handler
            switch (socketMessage.Type)
            {
                case (SlackWebSocketMessageType.hello):
                    var helloMessage = JsonConvert.DeserializeObject<HelloMessage>(messageEvent.Data);
                    await HelloHandler.Handle(helloMessage);
                    break;
                case (SlackWebSocketMessageType.slash_commands):
                    var slashCommandMessage = JsonConvert.DeserializeObject<SlashCommandMessage>(messageEvent.Data);
                    response = await SlashCommandHandler.Handle(slashCommandMessage);
                    break;
                case (SlackWebSocketMessageType.events_api):
                    var eventsApiMessage = JsonConvert.DeserializeObject<EventsAPIMessage>(messageEvent.Data);
                    response = await EventsAPIHandler.Handle(eventsApiMessage);
                    break;
                case (SlackWebSocketMessageType.disconnect):
                    await RefreshConnection(messageEvent.ConnectionId);
                    break;
                case (SlackWebSocketMessageType.interactive): // TODO
                default:
                    await DefaultHandler.Handle(socketMessage);
                    break;
            }

            // If the handle accepts a response, we got a message back from the handler to send.
            if (acceptsResponse)
            {
                await messageEvent.WebSocket.SendStringAsync(response.ToString());
            }
        }
    }
}
