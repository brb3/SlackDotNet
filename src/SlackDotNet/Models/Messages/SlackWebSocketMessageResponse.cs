using Newtonsoft.Json;
using SlackDotNet.Models.Messages;

namespace SlackDotNet.Models.Messages
{
    /// <summary>
    /// A message sent to Slack to acknowledge the receipt for a Web Socket message with optional Payload
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class SlackWebSocketMessageResponse
    {
        /// <summary>
        /// The ID of the message we want to acknowledge.
        /// </summary>
        [JsonProperty("envelope_id")]
        public string EnvelopeId { get; set; }

        [JsonProperty("payload")]
        public object Payload { get; set; } = null;

        public SlackWebSocketMessageResponse(SlackWebSocketMessage slackWebSocketMessage) => EnvelopeId = slackWebSocketMessage.EnvelopeId;

        /// <summary>
        /// Serializes the message object to a JSON string.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
