using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// A private channel was unarchived
    /// </summary>
    public class GroupUnarchive : EventsAPIPayload
    {
        public const string EventName = "group_unarchive";

        [JsonProperty("channel")]
        public string Channel { get; set; }
    }
}
