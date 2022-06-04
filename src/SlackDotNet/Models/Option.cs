using Newtonsoft.Json;

namespace SlackDotNet.Models
{
    public class Option
    {
        [JsonProperty("text")]
        public TextBlock Text { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("description")]
        public TextBlock Description { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
