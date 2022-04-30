using WebSocketExtensions;

namespace SlackDotNet
{
    internal class WebSocketWrapper : WebSocketClient
    {
        public bool Connected { get; set; } = false;
    }
}
