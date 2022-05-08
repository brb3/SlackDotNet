using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// User requested an invite
    /// </summary>
    public class InviteRequested : EventsAPIPayload
    {
        public const string EventName = "invite_requested";

        [JsonProperty("invite_request")]
        public object InviteRequest { get; set; } // TODO
    }
}
