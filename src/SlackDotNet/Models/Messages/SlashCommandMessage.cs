using SlackDotNet.Models.Messages.Payloads;

namespace SlackDotNet.Models.Messages
{
    public class SlashCommandMessage : SlackWebSocketMessage
    {
        public override object Payload { get => (SlashCommandPayload)Payload; set => base.Payload = value; }
    }
}
