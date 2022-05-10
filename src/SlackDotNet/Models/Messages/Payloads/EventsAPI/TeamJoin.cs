using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// A new member has joined
    /// </summary>
    public class TeamJoin : EventsAPIPayload
    {
        public const string EventName = "team_join";

        [JsonProperty("user")]
        public object User { get; set; } // TODO
    }
}
