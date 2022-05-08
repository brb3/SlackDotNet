using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// A pin was removed from a channel
    /// </summary>
    public class PinRemoved : EventsAPIPayload
    {
        public const string EventName = "pin_removed";

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }

        [JsonProperty("item")]
        public object Item { get; set; } // TODO

        [JsonProperty("has_pins")]
        public bool HasPins { get; set; }

        [JsonProperty("event_ts")]
        public string EventTS { get; set; }
    }
}
