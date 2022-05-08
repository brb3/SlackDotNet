using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// A file was deleted
    /// </summary>
    public class FileDeleted : EventsAPIPayload
    {
        public const string EventName = "file_deleted";

        [JsonProperty("file_id")]
        public string FileId { get; set; }

        [JsonProperty("event_ts")]
        public string EventTS { get; set; } // TODO: can this be converted to a Date?
    }
}
