using System.Threading.Tasks;
using SlackDotNet.Models.Messages;

namespace SlackDotNet.Handlers
{
    /// <summary>
    /// Handler for WebSocket "hello" messages.
    ///
    /// "hello" messages are sent from Slack immediately after a WebSocket connection has been established.
    /// </summary>
    public interface IHelloHandler
    {
        Task Handle(HelloMessage helloMessage);
    }
}
