using System;

namespace SlackDotNet.Exceptions
{
    /// <summary>
    /// Thrown when the Slack API responds in an unexpected way.
    /// </summary>
    public class SlackApiResponseException : Exception
    {
        public SlackApiResponseException(string message) : base(message)
        {
        }

        public SlackApiResponseException(string message, Exception e) : base(message, e)
        {
        }

    }
}
