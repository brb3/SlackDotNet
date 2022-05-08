using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// A user left a public or private channel
    /// </summary>
    public class MemberLeftChannel : EventsAPIPayload
    {
        public const string EventName = "member_left_channel";

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }

        /// <summary>
        /// `C` - A public channel
        /// `G` - Private channel (or group)
        /// </summary>
        [JsonProperty("channel_type")]
        public string ChannelType { get; set; }

        [JsonProperty("team")]
        public string Team { get; set; }
    }
}
