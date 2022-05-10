using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// A member's data has changed
    /// </summary>
    public class UserChange : EventsAPIPayload
    {
        public const string EventName = "user_change";

        [JsonProperty("user")]
        public object User { get; set; } // TODO
    }
}
