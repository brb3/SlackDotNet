using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// A file was made public
    /// </summary>
    public class FilePublic : EventsAPIPayload
    {
        public const string EventName = "file_public";

        [JsonProperty("file_id")]
        public string FileId { get; set; }

        [JsonProperty("file")]
        public object File { get; set; } // TODO
    }
}
