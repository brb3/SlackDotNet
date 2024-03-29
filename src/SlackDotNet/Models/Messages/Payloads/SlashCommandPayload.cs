using System;
using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads
{
    public class SlashCommandPayload : PayloadAbstract
    {
        [Obsolete("The Slack API no longer recommends using the verification token.")]
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("api_app_id")]
        public string ApiAppId { get; set; }

        [JsonProperty("team_id")]
        public string TeamId { get; set; }

        [JsonProperty("team_domain")]
        public string TeamDomain { get; set; }

        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }

        [JsonProperty("channel_name")]
        public string ChannelName { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("user_name")]
        public string UserName { get; set; }

        [JsonProperty("command")]
        public string Command { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("response_url")]
        public Uri ResponseUrl { get; set; }

        [JsonProperty("trigger_id")]
        public string TriggerId { get; set; }

        [JsonProperty("enterprise_id")]
        public string EnterpriseId { get; set; }

        [JsonProperty("enterprise_name")]
        public string EnterpriseName { get; set; }
    }
}
