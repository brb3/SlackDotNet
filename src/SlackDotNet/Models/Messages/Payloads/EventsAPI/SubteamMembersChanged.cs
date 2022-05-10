using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// The membership of an existing User Group has changed
    /// </summary>
    public class SubteamMembersChanged : EventsAPIPayload
    {
        public const string EventName = "subteam_members_changed";

        [JsonProperty("subteam_id")]
        public string SubteamId { get; set; }

        [JsonProperty("team_id")]
        public string TeamId { get; set; }

        [JsonConverter(typeof(UnixDateTimeConverter))]
        [JsonProperty("date_previous_update")]
        public DateTime DatePreviousUpdate { get; set; }

        [JsonConverter(typeof(UnixDateTimeConverter))]
        [JsonProperty("date_update")]
        public DateTime DateUpdate { get; set; }

        [JsonProperty("added_users")]
        public List<string> AddedUsers { get; set; }

        [JsonProperty("added_users_count")]
        public int AddedUsersCount { get; set; }

        [JsonProperty("removed_users")]
        public List<string> RemovedUsers { get; set; }

        [JsonProperty("removed_users_count")]
        public int RemovedUsersCount { get; set; }
    }
}
