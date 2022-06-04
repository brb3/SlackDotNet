using Newtonsoft.Json;

namespace SlackDotNet.Models
{
    public class OpenViewRequest
    {
        [JsonProperty("trigger_id")]
        public string TriggerId { get; set; }

        [JsonProperty("view")]
        public View View { get; set; }
    }
}
