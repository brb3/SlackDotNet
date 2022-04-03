using System.Threading.Tasks;
using SlackDotNet.Models.Messages;

namespace SlackDotNet.Handlers
{
    public interface ISlashCommandHandler
    {
        Task<SlackWebSocketMessageResponse> Handle(SlashCommandMessage slashCommandMessage);
    }
}
