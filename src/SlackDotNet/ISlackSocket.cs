using System.Threading.Tasks;

namespace SlackDotNet
{
    /// <summary>
    /// Provides a WebSocket connection from Slack.
    /// </summary>
    public interface ISlackSocket
    {
        /// <summary>
        /// Connects to the Slack Socket Mode API.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="SlackDotNet.Exceptions.SlackSocketConnectionException"></exception>
        Task Connect();

        /// <summary>
        /// Handles messages from the Slack WebSocket by calling configured Handlers.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        Task HandleMessage(string message);
    }
}
