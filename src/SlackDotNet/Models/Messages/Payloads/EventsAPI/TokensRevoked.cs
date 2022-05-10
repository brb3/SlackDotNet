using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// API tokens for your app were revoked.
    /// </summary>
    public class TokensRevoked : EventsAPIPayload
    {
        public const string EventName = "tokens_revoked";

        [JsonProperty("tokens")]
        public object Tokens { get; set; } // TODO
    }
}
