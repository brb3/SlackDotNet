using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// An existing User Group has been updated or its members changed
    /// </summary>
    public class SubteamUpdated : EventsAPIPayload
    {
        public const string EventName = "subteam_updated";

        [JsonProperty("subteam")]
        public object Subteam { get; set; } // TODO
    }
}
