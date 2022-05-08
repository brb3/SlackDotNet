using System;
using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// The workspace domain has changed
    /// </summary>
    public class TeamDomainChange : EventsAPIPayload
    {
        public const string EventName = "team_domain_change";

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("domain")]
        public string Domain { get; set; }

        [JsonProperty("team_id")]
        public string TeamId { get; set; }
    }
}
