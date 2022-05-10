using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// A channel was unarchived
    /// </summary>
    public class ChannelUnarchive : EventsAPIPayload
    {
        public const string EventName = "channel_unarchive";

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }
    }
}
