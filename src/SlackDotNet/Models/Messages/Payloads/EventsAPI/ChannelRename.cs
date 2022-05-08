using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// A channel was renamed
    /// </summary>
    public class ChannelRename : EventsAPIPayload
    {
        public const string EventName = "channel_rename";

        [JsonProperty("channel")]
        public object Channel { get; set; } // TODO
    }
}
