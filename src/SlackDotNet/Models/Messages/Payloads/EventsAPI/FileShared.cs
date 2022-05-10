using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// A file was shared
    /// </summary>
    public class FileShared : EventsAPIPayload
    {
        public const string EventName = "file_shared";

        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }

        [JsonProperty("file_id")]
        public string FileId { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("file")]
        public object File { get; set; } // TODO

        [JsonProperty("event_ts")]
        public string EventTS { get; set; } // TODO: can this be converted to a Date?
    }
}
