using Newtonsoft.Json;

namespace SlackDotNet.Models
{
    public class Response
    {
        [JsonProperty("ok")]
        public bool Ok { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }
    }
}
