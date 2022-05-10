using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// A file was unshared
    /// </summary>
    public class FileUnshared : EventsAPIPayload
    {
        public const string EventName = "file_unshared";

        [JsonProperty("file_id")]
        public string FileId { get; set; }

        [JsonProperty("file")]
        public object File { get; set; } // TODO
    }
}
