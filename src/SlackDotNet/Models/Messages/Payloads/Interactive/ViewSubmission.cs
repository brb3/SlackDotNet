using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.Interactive
{
    public class ViewSubmission
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("team")]
        public object Team { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("view")]
        public View View { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("response_urls")]
        public List<object> ResponseUrls { get; set; }
    }
}
