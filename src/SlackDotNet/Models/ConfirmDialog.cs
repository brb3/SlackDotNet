using Newtonsoft.Json;

namespace SlackDotNet.Models
{
    public class ConfirmDialog
    {
        [JsonProperty("title")]
        public TextBlock Title { get; set; }

        [JsonProperty("text")]
        public TextBlock Text { get; set; }

        [JsonProperty("confirm")]
        public TextBlock Confirm { get; set; }

        [JsonProperty("deny")]
        public TextBlock Deny { get; set; }

        [JsonProperty("style")]
        public string Style { get; set; }
    }
}
