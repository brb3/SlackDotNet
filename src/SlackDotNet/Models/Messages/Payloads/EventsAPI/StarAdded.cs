using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// A member has starred an item
    /// </summary>
    public class StarAdded : EventsAPIPayload
    {
        public const string EventName = "star_added";

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("item")]
        public object Item { get; set; } // TODO

        [JsonProperty("event_ts")]
        public string EventTS { get; set; } // TODO: Can this be a Date?
    }
}
