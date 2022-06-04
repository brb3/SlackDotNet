using System.Threading.Tasks;
using SlackDotNet.Models;
using SlackDotNet.Models.Messages;

namespace SlackDotNet.Handlers
{
    /// <summary>
    /// Handler for WebSocket "interactive" messages.
    /// </summary>
    public interface IInteractiveHandler
    {
        Task<SlackWebSocketMessageResponse> Handle(InteractiveMessage interactiveMessage);
    }
}
