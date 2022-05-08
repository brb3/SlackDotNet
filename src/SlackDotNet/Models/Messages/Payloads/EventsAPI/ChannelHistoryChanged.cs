using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// Bulk updates were made to a channel's history
    /// </summary>
    public class ChannelHistoryChanged : EventsAPIPayload
    {
        public const string EventName = "channel_history_changed";

        [JsonProperty("latest")]
        public string Latest { get; set; }

        [JsonProperty("ts")]
        public string TS { get; set; } // TODO: Can this be converted to a Date?

        [JsonProperty("event_ts")]
        public string EventTS { get; set; } // TODO: Can this be converted to a Date?
    }
}
