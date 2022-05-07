using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SlackDotNet.Models.Messages;

namespace SlackDotNet.Handlers
{
    public class EventsAPIHandler : IEventsAPIHandler
    {
        private ILogger<EventsAPIHandler> Logger { get; }

        public EventsAPIHandler(ILogger<EventsAPIHandler> logger)
        {
            Logger = logger;
        }

        public async Task<SlackWebSocketMessageResponse> Handle(EventsAPIMessage eventsMessage)
        {
            await Task.Run(() =>
                Logger.LogWarning($"Received unhandled `{eventsMessage.Type}` message from WebSocket.")
            );

            return new SlackWebSocketMessageResponse(eventsMessage);
        }
    }
}
