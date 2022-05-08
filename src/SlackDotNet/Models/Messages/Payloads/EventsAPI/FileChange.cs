using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// A file was changed
    /// </summary>
    public class FileChange : EventsAPIPayload
    {
        public const string EventName = "file_change";

        [JsonProperty("file_id")]
        public string FileId { get; set; }

        [JsonProperty("file")]
        public object File { get; set; } // TODO
    }
}
