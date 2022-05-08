using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads
{
    public class EventsAPIPayload
    {
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
