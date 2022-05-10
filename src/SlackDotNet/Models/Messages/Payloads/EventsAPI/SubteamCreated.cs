using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// A User Group has been added to the workspace
    /// </summary>
    public class SubteamCreated : EventsAPIPayload
    {
        public const string EventName = "subteam_created";

        [JsonProperty("subteam")]
        public object Subteam { get; set; } // TODO
    }
}
