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
            Logger.LogInformation("Requesting WebSocket connection from Slack.");
            var response = await SlackURIs.AppConnectionsOpen
                .WithHeader("Authorization", $"Bearer {Options.AppLevelToken}")
                .PostAsync()
                .ReceiveJson<Connection>();

            if (!response.Ok)
            {
                throw new SocketConnectionException("Slack refused to open a Socket connection.");
            }

            Logger.LogInformation("Slack WebSocket connection open successfully.");
            WebSocketClient.MessageHandler = (e) => Task.Run(() => HandleMessage(e.Data));
            await WebSocketClient.ConnectAsync(response.Url.ToString());
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
