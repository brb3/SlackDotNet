using System.Threading.Tasks;
using SlackDotNet.Models.Messages;

namespace SlackDotNet.Handlers
{
    /// <summary>
    /// Handler for `/slash` commands sent via the WebSocket connection.
    /// </summary>
    public interface ISlashCommandHandler
    {
        Task<SlackWebSocketMessageResponse> Handle(SlashCommandMessage slashCommandMessage);
    }
}
