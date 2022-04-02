using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SlackDotNet.Enums;

namespace SlackDotNet.Models
{
    public class SlackWebSocketMessage
    {
        [JsonProperty("payload")]
        public object Payload { get; }

        [JsonProperty("envelope_id")]
        public string EnvelopeId { get; }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SlackWebSocketMessageType Type { get; }

        [JsonProperty("accepts_response_payload")]
        public bool AcceptsResponsePayload { get; }

        [JsonProperty("num_connections")]
        public int NumberOfConnections { get; }
    }
}
