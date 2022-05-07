using SlackDotNet.Models.Messages.Payloads;

namespace SlackDotNet.Models.Messages
{
    public class EventsAPIMessage : SlackWebSocketMessage
    {
        public override object Payload { get => (EventsAPIPayload)Payload; set => base.Payload = value; }
    }
}
