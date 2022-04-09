using System.Threading.Tasks;
using SlackDotNet.Models.Messages;

namespace SlackDotNet.Handlers
{
    /// <summary>
    /// This is the default WebSocket message handler for unknown message types.
    /// </summary>
    public interface IDefaultHandler
    {
        Task Handle(SlackWebSocketMessage message);
    }
}
