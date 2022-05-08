using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// A workflow step supported by your app was removed from a workflow
    /// </summary>
    public class WorkflowStepDeleted : EventsAPIPayload
    {
        public const string EventName = "workflow_step_deleted";

        [JsonProperty("workflow_id")]
        public string WorkflowId { get; set; }

        [JsonProperty("workflow_draft_configuration")]
        public object WorkflowDraftConfiguration { get; set; } // TODO

        [JsonProperty("workflow_published_configuration")]
        public object WorkflowPublishedConfiguration { get; set; } // TODO

        [JsonProperty("event_ts")]
        public string EventTS { get; set; } // TODO: Can this be a Date?
    }
}
