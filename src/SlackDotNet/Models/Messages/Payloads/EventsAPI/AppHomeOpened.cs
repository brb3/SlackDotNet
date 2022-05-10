using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// User clicked into your App Home
    /// </summary>
    public class AppHomeOpened : EventsAPIPayload
    {
        public const string EventName = "app_home_opened";

        [JsonProperty("user")]
        public string UserId { get; set; }

        [JsonProperty("channel")]
        public string ChannelId { get; set; }

        [JsonProperty("event_ts")]
        public string EventTS { get; set; } // TODO: Convert to a Date?

        [JsonProperty("tab")]
        public string Tab { get; set; }

        /// <summary>
        /// Included if the user opened a Home Tab and that tab had a view published at least once before.
        ///
        /// Contains the current state of the Home tab.
        /// </summary>
        [JsonProperty("view")]
        public object View { get; set; } // TODO
    }
}
