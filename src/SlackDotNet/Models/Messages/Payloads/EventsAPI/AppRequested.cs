using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// User requested to install an app.
    /// </summary>
    public class AppRequested : EventsAPIPayload
    {
        public const string EventName = "app_requested";

        [JsonProperty("app_request")]
        public object AppRequest { get; set; } // TODO
    }
}
