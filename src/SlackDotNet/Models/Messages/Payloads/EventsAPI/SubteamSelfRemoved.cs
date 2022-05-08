using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// You have been removed from a User Group
    /// </summary>
    public class SubteamSelfRemoved : EventsAPIPayload
    {
        public const string EventName = "subteam_self_removed";

        [JsonProperty("subteam_id")]
        public string SubteamId { get; set; }
    }
}
