namespace SlackDotNet.Responses
{
    public class Chat
    {
        public bool Ok { get; set; }
        public string Channel { get; set; }
        public string Ts { get; set; }
        public ChatMessage Message { get; set; }
        public string Permalink { get; set; }
        public string Error { get; set; }
    }
}