namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// Indicates your app's event subscriptions are being rate limited.
    /// </summary>
    public class AppRateLimited : EventsAPIPayload
    {
        public const string EventName = "app_rate_limited";
    }
}
