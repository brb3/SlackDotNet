using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// A user's profile data has changed
    /// </summary>
    public class UserProfileChanged : EventsAPIPayload
    {
        public const string EventName = "user_profile_changed";

        [JsonProperty("user")]
        public object User { get; set; } // TODO

        [JsonProperty("cache_ts")]
        public string CacheTS { get; set; } // TODO: Can this be a Date?

        [JsonProperty("event_ts")]
        public string EventTS { get; set; } // TODO: Can this be a Date?
    }
}
