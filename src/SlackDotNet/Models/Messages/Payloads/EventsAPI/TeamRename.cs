using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// The workspace name has changed
    /// </summary>
    public class TeamRename : EventsAPIPayload
    {
        public const string EventName = "team_rename";

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("team_id")]
        public string TeamId { get; set; }
    }
}
