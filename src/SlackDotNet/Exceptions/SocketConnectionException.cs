using System;

namespace SlackDotNet.Exceptions
{
    public class SocketConnectionException : Exception
    {
        public SocketConnectionException(string message) : base(message) { }
    }
}
