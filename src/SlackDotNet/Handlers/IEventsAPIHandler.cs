using System.Threading.Tasks;
using SlackDotNet.Models.Messages;

namespace SlackDotNet.Handlers
{
    /// <summary>
    /// Handler for WebSocket "events_api" messages.
    ///
    /// "events_api" messages are triggered by events that an application subscribes to.
    /// Read more about the Events API in Slack's <see href="https://api.slack.com/apis/connections/events-api">documentation</see>.
    /// </summary>
    public interface IEventsAPIHandler
    {
        Task<SlackWebSocketMessageResponse> Handle(EventsAPIMessage eventsMessage);
    }
}
