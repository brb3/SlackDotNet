using Flurl;

namespace SlackDotNet.Models
{
    /// <summary>
    /// Central location to retrieve API Endpoints for interacting with Slack.
    /// </summary>
    public static class SlackApiEndpoints
    {
        public static readonly Url Base = new Url("https://slack.com/api/");
        public static readonly Url AppConnectionsOpen = Base.AppendPathSegment("apps.connections.open");
    }
}
