using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// Do not Disturb settings changed for a member
    /// </summary>
    public class DndUpdatedUser : EventsAPIPayload
    {
        public const string EventName = "dnd_updated_user";

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("dnd_status")]
        public object DndStatus { get; set; } // TODO
    }
}
