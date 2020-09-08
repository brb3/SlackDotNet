using Newtonsoft.Json;

namespace SlackDotNet.Payloads
{
    public class ChatAttachment
    {
        [JsonProperty("pretext")]
        public string Pretext { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}