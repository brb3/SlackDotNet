using SlackDotNet.Models.Messages;

namespace SlackDotNet.Models
{
    public class InteractiveMessage : SlackWebSocketMessage
    {
        public override object Payload { get; set; }
    }
}
