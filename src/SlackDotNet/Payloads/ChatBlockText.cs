using Newtonsoft.Json;

namespace SlackDotNet.Payloads
{
    public class ChatBlockText
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}