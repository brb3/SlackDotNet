using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages
{
    public class DebugInfo
    {
        [JsonProperty("host")]
        public string Host { get; set; }

        [JsonProperty("started")]
        public string Started { get; set; }

        [JsonProperty("build_number")]
        public string BuildNumber { get; set; }

        [JsonProperty("approximate_connection_time")]
        public int ApproximateConnectionTime { get; set; }
    }
}
