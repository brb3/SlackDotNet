using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// You opened a DM
    /// </summary>
    public class ImOpen : EventsAPIPayload
    {
        public const string EventName = "im_open";

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }
    }
}
