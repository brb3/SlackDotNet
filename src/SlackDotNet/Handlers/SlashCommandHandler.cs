using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SlackDotNet.Models.Messages;

namespace SlackDotNet.Handlers
{
    public class SlashCommandHandler : ISlashCommandHandler
    {
        private ILogger<SlashCommandHandler> Logger { get; }

        public SlashCommandHandler(ILogger<SlashCommandHandler> logger)
        {
            Logger = logger;
        }

        public async Task<SlackWebSocketMessageResponse> Handle(SlashCommandMessage slashCommandMessage)
        {
            await Task.Run(() =>
                Logger.LogWarning($"Received unhandled `{slashCommandMessage.Type}` message from WebSocket.")
            );

            return new SlackWebSocketMessageResponse(slashCommandMessage);
        }
    }
}
