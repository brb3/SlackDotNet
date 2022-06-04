using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackDotNet.Models
{
    public class ViewSubmissionState
    {
        [JsonProperty("values")]
        public Dictionary<string, object> Values { get; set; }
    }
}
