using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// A channel has been shared with an external workspace
    /// </summary>
    public class ChannelShared : EventsAPIPayload
    {
        public const string EventName = "channel_shared";

        [JsonProperty("connected_team_id")]
        public string ConnectedTeamId { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("event_ts")]
        public string EventTS { get; set; } // TODO: Can this be converted to a Date?
    }
}
