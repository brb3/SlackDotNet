using System;

namespace SlackDotNet.Exceptions
{
    /// <summary>
    /// Thrown when Slack refuses to make a WebSocket connection
    /// </summary>
    public class SocketConnectionException : Exception
    {
        public SocketConnectionException(string message) : base(message) { }
    }
}
