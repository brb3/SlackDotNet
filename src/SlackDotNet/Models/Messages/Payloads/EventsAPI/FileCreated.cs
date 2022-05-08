using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// A file was created
    /// </summary>
    public class FileCreated : EventsAPIPayload
    {
        public const string EventName = "file_created";

        [JsonProperty("file_id")]
        public string FileId { get; set; }

        [JsonProperty("file")]
        public object File { get; set; } // TODO
    }
}
