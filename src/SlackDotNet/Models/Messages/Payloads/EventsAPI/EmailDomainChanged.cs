using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// The workspace email domain has changed
    /// </summary>
    public class EmailDomainChanged : EventsAPIPayload
    {
        public const string EventName = "email_domain_changed";

        [JsonProperty("email_domain")]
        public string EmailDomain { get; set; }

        [JsonProperty("event_ts")]
        public string EventTS { get; set; } // TODO: Can this be converted to a Date?
    }
}
