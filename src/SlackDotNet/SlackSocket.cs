using System;
using System.Threading.Tasks;
using Flurl.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SlackDotNet.Enums;
using SlackDotNet.Exceptions;
using SlackDotNet.Models;
using SlackDotNet.Models.Responses;
using WebSocketExtensions;

namespace SlackDotNet
{
    public class SlackSocket : ISlackSocket, IDisposable
    {
        private SlackOptions Options { get; set; }
        private WebSocketClient WebSocketClient { get; set; } = new WebSocketClient();
        private ILogger<SlackSocket> Logger { get; }

        public SlackSocket(IOptions<SlackOptions> options, ILogger<SlackSocket> logger)
        {
            Options = options.Value;
            Logger = logger;
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

            // After receiving a message from the WebSocket, we need to first ack the message to prevent resends.
            if (!String.IsNullOrEmpty(socketMessage.EnvelopeId))
            {
                var ack = new Acknowledge(socketMessage);
                await WebSocketClient.SendStringAsync(ack.ToString());
            }

            // "hello" messages are handled internally and logged
            if (socketMessage.Type == SlackWebSocketMessageType.hello)
            {
                Logger.LogInformation(
                    $"Received `hello` from WebSocket. Number of Connections: {socketMessage.NumberOfConnections}"
                );
            }
        }
    }
}
