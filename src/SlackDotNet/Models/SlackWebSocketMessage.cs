using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SlackDotNet.Enums;

namespace SlackDotNet.Models
{
    /// <summary>
    /// Represents a WebSocket message received from Slack.
    /// </summary>
    public class SlackWebSocketMessage
    {
        /// <summary>
        /// The payload schema varies by `Type`.
        /// </summary>
        [JsonProperty("payload")]
        public object Payload { get; }

        /// <summary>
        /// A unique identifier for this message.
        /// </summary>
        [JsonProperty("envelope_id")]
        public string EnvelopeId { get; }

        /// <summary>
        /// The type of message that Slack is sending.
        /// </summary>
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SlackWebSocketMessageType Type { get; }

        /// <summary>
        /// Does this message accept a response directly vie the WebSocket?
        /// </summary>
        [JsonProperty("accepts_response_payload")]
        public bool AcceptsResponsePayload { get; }

        /// <summary>
        /// How many connections are currently active. Appears to only be used during the `hello` message.
        /// </summary>
        [JsonProperty("num_connections")]
        public int NumberOfConnections { get; }
    }
}
