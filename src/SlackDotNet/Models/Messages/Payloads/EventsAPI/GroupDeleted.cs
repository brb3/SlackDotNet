using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// A private channel was deleted
    /// </summary>
    public class GroupDeleted : EventsAPIPayload
    {
        public const string EventName = "group_deleted";

        [JsonProperty("channel")]
        public string Channel { get; set; }
    }
}
