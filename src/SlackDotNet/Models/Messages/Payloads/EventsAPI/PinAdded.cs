using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// A pin was added to a channel
    /// </summary>
    public class PinAdded : EventsAPIPayload
    {
        public const string EventName = "pin_added";

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }

        [JsonProperty("item")]
        public object Item { get; set; } // TODO

        [JsonProperty("event_ts")]
        public string EventTS { get; set; } // TODO: Can this be a Date?
    }
}
