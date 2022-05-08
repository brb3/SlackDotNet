using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// A message was posted containing one or more links relevant to your application
    ///
    /// Received when the user is composing the message, and again when sent.
    /// </summary>
    public class LinkShared : EventsAPIPayload
    {
        public const string EventName = "link_shared";

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("is_bot_user_member")]
        public bool IsBotUserMember { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("message_ts")]
        public string MessageTS { get; set; } // TODO: Can this be converted to a Date?

        [JsonProperty("unfurl_id")]
        public string UnfurlId { get; set; }

        [JsonProperty("thread_ts")]
        public string ThreadTS { get; set; } // TODO: Can this be converted to a Date?

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("links")]
        public List<object> Links { get; set; } // TODO
    }
}
