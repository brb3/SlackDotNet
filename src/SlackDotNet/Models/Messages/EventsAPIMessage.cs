using Newtonsoft.Json;
using SlackDotNet.Models.Messages.Payloads;

namespace SlackDotNet.Models.Messages
{
    public class EventsAPIMessage : SlackWebSocketMessage
    {
        [JsonConverter(typeof(EventsAPIPayloadConverter))]
        public override object Payload { get; set; }
    }
}
