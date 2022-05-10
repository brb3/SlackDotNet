using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// A private channel was renamed
    /// </summary>
    public class GroupRename : EventsAPIPayload
    {
        public const string EventName = "group_rename";

        [JsonProperty("channel")]
        public object Channel { get; set; } // TODO
    }
}
