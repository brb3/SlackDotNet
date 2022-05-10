using System.Threading.Tasks;
using WebSocketExtensions;

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
        Task Connect(int activeConnections = 2);

        /// <summary>
        /// Handles messages from the Slack WebSocket by calling configured Handlers.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="socketIndex">WebSocket to use to respond to the message. (Index of available sockets)</param>
        /// <returns></returns>
        Task HandleMessage(StringMessageReceivedEventArgs messageEvent);

        /// <summary>
        /// Determines if a message's envelopedId has already been handled.
        /// </summary>
        /// <param name="envelopeId"></param>
        /// <returns></returns>
        bool MessageHasBeenHandled(string envelopeId);
    }
}
