using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// You closed a DM
    /// </summary>
    public class ImClose : EventsAPIPayload
    {
        public const string EventName = "im_close";

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }
    }
}
