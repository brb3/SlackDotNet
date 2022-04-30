using System.Net.WebSockets;
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
        /// <param name="activeConnections">The amount of socket connections to create.</param>
        /// <returns></returns>
        /// <exception cref="SlackDotNet.Exceptions.SlackSocketConnectionException"></exception>
        Task Connect(int activeConnections);

        /// <summary>
        /// Handles messages from the Slack WebSocket by calling configured Handlers.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="socket">WebSocket to use to respond to the message.</param>
        /// <returns></returns>
        Task HandleMessage(string message, WebSocket socket);

        /// <summary>
        /// Determines if a message's envelopedId has already been handled.
        /// </summary>
        /// <param name="envelopeId"></param>
        /// <returns></returns>
        bool MessageHasBeenHandled(string envelopeId);
    }
}
