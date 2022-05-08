using SlackDotNet.Models.Messages.Payloads;

namespace SlackDotNet.Models.Messages
{
    public class EventsAPIMessage : SlackWebSocketMessage
    {
        // TODO: need to read the Payload.type and build the Models.Message.Payloads.EventsApi model that matches
        public override object Payload { get => (EventsAPIPayload)Payload; set => base.Payload = value; }
    }
}
