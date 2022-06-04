using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackDotNet.Models.Responses
{
    public class Emojis
    {
        [JsonProperty("ok")]
        public bool Ok { get; set; }

        [JsonProperty("emoji")]
        public Dictionary<string, Uri> EmojiDictionary { get; set; }
    }
}
