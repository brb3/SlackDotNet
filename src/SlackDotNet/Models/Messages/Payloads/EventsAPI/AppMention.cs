using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// A user mentions your bot user.
    ///
    /// If a user mentions your bot user in a channel it isn't in, they can invite the bot user.
    /// This will also trigger an `app_mention` event.
    /// </summary>
    public class AppMention : EventsAPIPayload
    {
        public const string EventName = "app_mention";

        [JsonProperty("user")]
        public string UserId { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("ts")]
        public string TS { get; set; } // TODO: Convert to Date?

        [JsonProperty("channel")]
        public string ChannelId { get; set; }

        [JsonProperty("event_ts")]
        public string EventTS { get; set; } // TODO: Convert to Date?
    }
}
