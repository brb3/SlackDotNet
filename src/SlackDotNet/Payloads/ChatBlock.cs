using Newtonsoft.Json;

namespace SlackDotNet.Payloads
{
    public class ChatBlock
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("text")]
        public ChatBlockText Text { get; set; }
    }
}