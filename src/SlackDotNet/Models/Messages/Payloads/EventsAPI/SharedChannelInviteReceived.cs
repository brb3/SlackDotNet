using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// A shared channel invite was sent to a Slack User
    /// </summary>
    public class SharedChannelInviteReceived : EventsAPIPayload
    {
        public const string EventName = "shared_channel_invite_received";

        [JsonProperty("invite")]
        public object Invite { get; set; } // TODO

        [JsonProperty("channel")]
        public object Channel { get; set; } // TODO

        [JsonProperty("event_ts")]
        public string EventTS { get; set; } // TODO: Can this be a Date?
    }
}
