using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// A workflow that contains a step supported by your app was published
    /// </summary>
    public class WorkflowPublished : EventsAPIPayload
    {
        public const string EventName = "workflow_published";

        [JsonProperty("workflow_id")]
        public string WorkflowId { get; set; }

        [JsonProperty("workflow_published_configuration")]
        public object WorkflowPublishedConfiguration { get; set; } // TODO

        [JsonProperty("event_ts")]
        public string EventTS { get; set; } // TODO: Can this be a Date?
    }
}
