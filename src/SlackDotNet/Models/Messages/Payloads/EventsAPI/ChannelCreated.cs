using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// A channel was created
    /// </summary>
    public class ChannelCreated : EventsAPIPayload
    {
        public const string EventName = "channel_created";

        [JsonProperty("channel")]
        public object Channel { get; set; } // TODO
    }
}
