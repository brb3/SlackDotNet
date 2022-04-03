using System.Threading.Tasks;
using SlackDotNet.Models.Messages;

namespace SlackDotNet.Handlers
{
    public interface IDefaultHandler
    {
        Task Handle(SlackWebSocketMessage message);
    }
}
