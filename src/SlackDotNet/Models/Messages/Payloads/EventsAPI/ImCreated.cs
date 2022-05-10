using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// A DM was created
    /// </summary>
    public class ImCreated : EventsAPIPayload
    {
        public const string EventName = "im_created";

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("channel")]
        public object Channel { get; set; } // TODO
    }
}
