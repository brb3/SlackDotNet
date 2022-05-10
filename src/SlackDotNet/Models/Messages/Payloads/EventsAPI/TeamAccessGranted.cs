using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// Access to a set of teams was granted to your org app
    /// </summary>
    public class TeamAccessGranted : EventsAPIPayload
    {
        public const string EventName = "team_access_granted";

        [JsonProperty("team_ids")]
        public List<string> TeamIds { get; set; }
    }
}
