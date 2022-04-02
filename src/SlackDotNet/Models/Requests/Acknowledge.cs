using Newtonsoft.Json;

namespace SlackDotNet.Models
{
    /// <summary>
    /// A message sent to Slack to acknowledge the receipt for a Web Socket message.
    /// </summary>
    public class Acknowledge
    {
        /// <summary>
        /// The ID of the message we want to acknowledge.
        /// </summary>
        [JsonProperty("envelope_id")]
        public string EnvelopeId { get; }

        public Acknowledge(SlackWebSocketMessage slackWebSocketMessage) => EnvelopeId = slackWebSocketMessage.EnvelopeId;

        /// <summary>
        /// Serializes the Acknowledge object to a JSON string.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
