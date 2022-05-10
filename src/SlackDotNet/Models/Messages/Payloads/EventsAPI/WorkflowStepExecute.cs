using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// A workflow step supported by your app should execute
    /// </summary>
    public class WorkflowStepExecute : EventsAPIPayload
    {
        public const string EventName = "workflow_step_execute";

        [JsonProperty("callback_id")]
        public string CallbackId { get; set; }

        [JsonProperty("workflow_step")]
        public object WorkflowStep { get; set; } // TODO
    }
}
