using System.Threading.Tasks;

namespace SlackDotNet
{
    public interface ISlackSocket
    {
        /// <summary>
        /// Connects to the Slack Socket Mode API.
        /// </summary>
        /// <returns></returns>
        Task Connect();

        /// <summary>
        /// Handles messages from the Slack WebSocket by calling configured Handlers.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        Task HandleMessage(string message);
    }
}
