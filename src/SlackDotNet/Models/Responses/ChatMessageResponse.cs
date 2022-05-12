using Newtonsoft.Json;
using SlackDotNet.Models.Messages;

namespace SlackDotNet.Models.Responses
{
    public class ChatMessageResponse
    {
        [JsonProperty("ok")]
        public bool Ok { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("ts")]
        public string Timestamp { get; set; }

        [JsonProperty("message")]
        public ChatMessage Message  { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
