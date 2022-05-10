using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// Bulk updates were made to a DM's history
    /// </summary>
    public class ImHistoryChanged : EventsAPIPayload
    {
        public const string EventName = "im_history_changed";

        [JsonProperty("latest")]
        public string Latest { get; set; } // TODO: Can this be a Date?

        [JsonProperty("ts")]
        public string TS { get; set; } // TODO: Can this be a Date?

        [JsonProperty("event_ts")]
        public string EventTS { get; set; } // TODO: Can this be a Date?
    }
}
