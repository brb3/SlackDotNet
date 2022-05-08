using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// A custom emoji has been added or changed
    /// </summary>
    public class EmojiChanged : EventsAPIPayload
    {
        public const string EventName = "emoji_changed";

        /// <summary>
        /// Can be `add`, `remove`, or `rename`
        /// </summary>
        [JsonProperty("subtype")]
        public string Subtype { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("names")]
        public List<string> Names { get; set; }

        [JsonProperty("value")]
        public Uri Value { get; set; }

        [JsonProperty("old_name")]
        public string OldName { get; set; }

        [JsonProperty("new_name")]
        public string NewName { get; set; }

        [JsonProperty("event_ts")]
        public string EventTS { get; set; } // TODO: can this be converted to a Date?
    }
}
