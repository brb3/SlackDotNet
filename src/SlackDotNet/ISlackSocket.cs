using System;
using System.Threading.Tasks;
using SlackDotNet.Models;
using SlackDotNet.Models.Messages;

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

        /// <summary>
        /// Determines if a message's envelopedId has already been handled.
        /// </summary>
        /// <param name="envelopeId"></param>
        /// <returns></returns>
        bool MessageHasBeenHandled(string envelopeId);
    }
}
