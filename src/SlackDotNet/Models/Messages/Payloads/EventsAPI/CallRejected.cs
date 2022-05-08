using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// A Call was rejected
    /// </summary>
    public class CallRejected : EventsAPIPayload
    {
        public const string EventName = "call_rejected";

        [JsonProperty("call_id")]
        public string CallId { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }

        [JsonProperty("external_unique_id")]
        public string ExternalUniqueId { get; set; }
    }
}
