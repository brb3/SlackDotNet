using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// You left a private channel
    /// </summary>
    public class GroupLeft : EventsAPIPayload
    {
        public const string EventName = "group_left";

        [JsonProperty("channel")]
        public string Channel { get; set; }
    }
}
