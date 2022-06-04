using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SlackDotNet.Models;
using SlackDotNet.Models.Messages;

namespace SlackDotNet.Handlers
{
    public class InteractiveHandler : IInteractiveHandler
    {
        public ILogger<InteractiveHandler> Logger { get; }

        public InteractiveHandler(ILogger<InteractiveHandler> logger)
        {
            Logger = logger;
        }

        public async Task<SlackWebSocketMessageResponse> Handle(InteractiveMessage interactiveMessage)
        {
            await Task.Run(() =>
                Logger.LogWarning($"Received unhandled `{interactiveMessage.Type}` message from WebSocket.")
            );

            return new SlackWebSocketMessageResponse(interactiveMessage);
        }
    }
}
