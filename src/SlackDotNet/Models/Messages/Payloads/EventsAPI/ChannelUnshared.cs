using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// A channel has been unshared with an external workspace
    /// </summary>
    public class ChannelUnshared : EventsAPIPayload
    {
        public const string EventName = "channel_unshared";

        [JsonProperty("previously_connected_team_id")]
        public string PreviouslyConnectedTeamId { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("is_ext_shared")]
        public bool IsExternallyShared { get; set; }

        [JsonProperty("event_ts")]
        public string EventTS { get; set; } // TODO: can this be converted to a Date?
    }
}
