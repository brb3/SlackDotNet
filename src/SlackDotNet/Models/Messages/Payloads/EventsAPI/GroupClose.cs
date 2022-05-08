using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// You closed a private channel
    /// </summary>
    public class GroupClose : EventsAPIPayload
    {
        public const string EventName = "group_close";

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }
    }
}
