using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// You left a channel
    /// </summary>
    public class ChannelLeft : EventsAPIPayload
    {
        public const string EventName = "channel_left";

        [JsonProperty("channel")]
        public string Channel { get; set; }
    }
}
