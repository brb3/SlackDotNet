using Newtonsoft.Json;

namespace SlackDotNet.Models
{
    public class Acknowledge
    {
        [JsonProperty("envelope_id")]
        public string EnvelopeId { get; }

        public Acknowledge(SlackWebSocketMessage slackWebSocketMessage) => EnvelopeId = slackWebSocketMessage.EnvelopeId;

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
