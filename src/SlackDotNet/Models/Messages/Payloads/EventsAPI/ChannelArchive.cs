using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// A channel was archived
    /// </summary>
    public class ChannelArchive : EventsAPIPayload
    {
        public const string EventName = "channel_archive";

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }
    }
}
