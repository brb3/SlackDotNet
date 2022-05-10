using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// You have been added to a User Group
    /// </summary>
    public class SubteamSelfAdded : EventsAPIPayload
    {
        public const string EventName = "subteam_self_added";

        [JsonProperty("subteam_id")]
        public string SubteamId { get; set; }
    }
}
