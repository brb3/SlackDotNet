using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// You created a group DM
    /// </summary>
    public class GroupOpen : EventsAPIPayload
    {
        public const string EventName = "group_open";

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }
    }
}
