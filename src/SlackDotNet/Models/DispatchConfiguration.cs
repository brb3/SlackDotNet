using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackDotNet.Models
{
    public class DispatchConfiguration
    {
        [JsonProperty("trigger_actions_on")]
        public List<string> TriggerActionsOn { get; set; }
    }
}
