using System;

namespace SlackDotNet.Exceptions
{
    /// <summary>
    /// Thrown when Slack refuses to make a WebSocket connection
    /// </summary>
    public class SlackSocketConnectionException : Exception
    {
        public SlackSocketConnectionException(string message) : base(message)
        {
        }

        public SlackSocketConnectionException(string message, Exception e) : base(message, e)
        {
        }
    }
}
