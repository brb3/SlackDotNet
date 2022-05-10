using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackDotNet.Models
{
    public class Filter
    {
        [JsonProperty("include")]
        public List<string> Include { get; set; }

        [JsonProperty("exclude_external_shared_channels")]
        public bool ExcludeExternalSharedChannels { get; set; }

        [JsonProperty("exclude_bot_users")]
        public bool ExcludeBotUsers { get; set; }
    }
}
