using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SlackDotNet.Models.Messages;

namespace SlackDotNet.Handlers
{
    public class DefaultHandler : IDefaultHandler
    {
        private ILogger<DefaultHandler> Logger { get; }

        public DefaultHandler(ILogger<DefaultHandler> logger)
        {
            Logger = logger;
        }

        public async Task Handle(SlackWebSocketMessage message)
        {
            await Task.Run(() =>
                Logger.LogWarning($"Received unknown `{message.Type}` message from WebSocket.")
            );
        }
    }
}
