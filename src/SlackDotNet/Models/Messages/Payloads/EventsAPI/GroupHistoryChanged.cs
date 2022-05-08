using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// Bulk updates were made to a private channel's history
    /// </summary>
    public class GroupHistoryChanged : EventsAPIPayload
    {
        public const string EventName = "group_history_changed";

        [JsonProperty("latest")]
        public string Latest { get; set; } // TODO: Could this be converted to a Date?

        [JsonProperty("ts")]
        public string TS { get; set; } // TODO: Could this be converted to a Date?

        [JsonProperty("event_ts")]
        public string EventTS { get; set; } // TODO: Could this be converted to a Date?
    }
}
