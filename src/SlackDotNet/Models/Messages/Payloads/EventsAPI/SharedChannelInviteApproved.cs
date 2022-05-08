using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// A shared channel invite was approved
    /// </summary>
    public class SharedChannelInviteApproved : EventsAPIPayload
    {
        public const string EventName = "shared_channel_invite_approved";

        [JsonProperty("invite")]
        public object Invite { get; set; } // TODO

        [JsonProperty("channel")]
        public object Channel { get; set; } // TODO

        [JsonProperty("teams_in_channel")]
        public List<object> TeamsInChannel { get; set; } // TODO

        [JsonProperty("accepting_user")]
        public object AcceptingUser { get; set; } // TODO

        [JsonProperty("event_ts")]
        public string EventTS { get; set; } // TODO: Can this be a Date?
    }
}
