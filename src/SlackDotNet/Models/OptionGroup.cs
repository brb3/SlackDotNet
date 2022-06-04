using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackDotNet.Models
{
    public class OptionGroup
    {
        [JsonProperty("label")]
        public TextBlock Label { get; set; }

        [JsonProperty("options")]
        public List<Option> Options { get; set; }
    }
}
