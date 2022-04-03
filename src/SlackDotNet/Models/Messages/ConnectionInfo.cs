using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages
{
    public class ConnectionInfo
    {
        [JsonProperty("app_id")]
        public string AppId { get; set; }
    }
}
