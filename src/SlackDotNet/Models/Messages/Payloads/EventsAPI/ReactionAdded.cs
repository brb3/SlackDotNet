using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// A member has added an emoji reaction to an item
    /// </summary>
    public class ReactionAdded : EventsAPIPayload
    {
        public const string EventName = "reaction_added";

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("reaction")]
        public string Reaction { get; set; }

        [JsonProperty("item_user")]
        public string ItemUser { get; set; }

        [JsonProperty("item")]
        public object Item { get; set; } // TODO

        [JsonProperty("event_ts")]
        public string EventTS { get; set; } // TODO: Can this be a Date?
    }
}
