using Newtonsoft.Json;

namespace SlackDotNet.Models.Responses
{
    public class PublishViewResponse
    {
        [JsonProperty("ok")]
        public bool Ok { get; set; }

        [JsonProperty("view")]
        public View View { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("response_metadata")]
        public object ResponseMetadata { get; set; }
    }
}
