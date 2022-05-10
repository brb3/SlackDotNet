using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// Do not Disturb settings changed for the current user
    /// </summary>
    public class DndUpdated : EventsAPIPayload
    {
        public const string EventName = "dnd_updated";

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("dnd_status")]
        public object DndStatus { get; set; } // TODO
    }
}
