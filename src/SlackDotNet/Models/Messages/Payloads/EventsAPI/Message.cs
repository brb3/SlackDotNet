using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// A message was sent to a channel
    /// </summary>
    public class Message : EventsAPIPayload
    {
        public const string EventName = "message";

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("channel_type")]
        public string ChannelType { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("ts")]
        public string TS { get; set; } // TODO: Can this be a Date?

        [JsonProperty("event_ts")]
        public string EventTS { get; set; } // TODO: Can this be a Date?
    }
}
