using System.Collections.Generic;

namespace SlackDotNet.Responses
{
    public class ChatMessage
    {
        public string Text { get; set; }
        public string Username { get; set; }
        public string BotId { get; set; }
        public List<ChatAttachment> Attachments { get; set; }
        public string Type { get; set; }
        public string Subtype { get; set; }
        public string Ts { get; set; }
    }
}