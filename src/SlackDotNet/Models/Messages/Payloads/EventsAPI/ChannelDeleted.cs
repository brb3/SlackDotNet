using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// A channel was deleted
    /// </summary>
    public class ChannelDeleted : EventsAPIPayload
    {
        public const string EventName = "channel_deleted";

        [JsonProperty("channel")]
        public string Channel { get; set; }
    }
}
