using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// A member removed a star
    /// </summary>
    public class StarRemoved : EventsAPIPayload
    {
        public const string EventName = "star_removed";

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("item")]
        public object Item { get; set; } // TODO

        [JsonProperty("event_ts")]
        public string EventTS { get; set; } // TODO: Can this be a Date?
    }
}
