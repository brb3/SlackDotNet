using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// A channel ID changed
    /// </summary>
    public class ChannelIdChanged : EventsAPIPayload
    {
        public const string EventName = "channel_id_changed";

        [JsonProperty("old_channel_id")]
        public string OldChannelId { get; set; }

        [JsonProperty("new_channel_id")]
        public string NewChannelId { get; set; }

        [JsonProperty("event_ts")]
        public string EventTS { get; set; } // TODO: Can this be converted to a Date?
    }
}
