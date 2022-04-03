using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SlackDotNet.Enums;

namespace SlackDotNet.Models.Messages
{
    /// <summary>
    /// Represents a WebSocket message received from Slack.
    /// </summary>
    public abstract class AbstractWebSocketMessage
    {
        /// <summary>
        /// The payload schema varies by `Type`.
        /// </summary>
        [JsonProperty("payload")]
        public object Payload { get; set; }

        /// <summary>
        /// A unique identifier for this message.
        /// </summary>
        [JsonProperty("envelope_id")]
        public string EnvelopeId { get; set; }

        /// <summary>
        /// The type of message that Slack is sending.
        /// </summary>
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SlackWebSocketMessageType Type { get; set; }

        /// <summary>
        /// Does this message accept a response directly vie the WebSocket?
        /// </summary>
        [JsonProperty("accepts_response_payload")]
        public bool AcceptsResponsePayload { get; set; }
    }
}
