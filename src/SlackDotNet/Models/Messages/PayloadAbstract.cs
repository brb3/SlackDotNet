using Newtonsoft.Json;
using SlackDotNet.Models.Messages.Payloads;

namespace SlackDotNet.Models.Messages
{
    /// <summary>
    /// Payload object that all other payloads derive from.
    /// </summary>
    public abstract class PayloadAbstract
    {
        [JsonProperty("type")]
        public PayloadType Type { get; set; }
    }
}
