using Newtonsoft.Json;

namespace SlackDotNet.Models
{
    public class PublishViewRequest
    {
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("view")]
        public View View { get; set; }
    }
}
