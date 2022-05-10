using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// A workflow that contains a step supported by your app was unpublished
    /// </summary>
    public class WorkflowUnpublished : EventsAPIPayload
    {
        public const string EventName = "workflow_unpublished";

        [JsonProperty("workflow_id")]
        public string WorkflowId { get; set; }

        [JsonProperty("workflow_draft_configuration")]
        public object WorkflowDraftConfiguration { get; set; } // TODO:

        [JsonProperty("event_ts")]
        public string EventTS { get; set; } // TODO: Can this be a Date?
    }
}
