namespace SlackDotNet.Models.Messages.Payloads.EventsAPI
{
    /// <summary>
    /// Your Slack app was uninstalled.
    /// </summary>
    public class AppUninstalled : EventsAPIPayload
    {
        public const string EventName = "app_uninstalled";
    }
}
