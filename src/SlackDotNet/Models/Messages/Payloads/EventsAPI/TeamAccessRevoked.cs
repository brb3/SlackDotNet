using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// Access to a set of teams was revoked from your org app
    /// </summary>
    public class TeamAccessRevoked : EventsAPIPayload
    {
        public const string EventName = "team_access_revoked";

        [JsonProperty("team_ids")]
        public List<string> TeamIds  { get; set; }
    }
}
