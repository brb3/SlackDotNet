using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// A private channel was archived
    /// </summary>
    public class GroupArchive : EventsAPIPayload
    {
        public const string EventName = "group_archive";

        [JsonProperty("channel")]
        public string Channel { get; set; }
    }
}
