namespace SlackDotNet.Enums
{
    /// <summary>
    /// Slack's WebSocket sends different types of messages.
    /// A message's `payload` property will vary based on the message type.
    /// </summary>
    public enum SlackWebSocketMessageType
    {
        /// <summary>
        /// This message is sent immediately after a WebSocket connection has been established.
        /// </summary>
        hello,

        /// <summary>
        /// Slash Commands are a type of interactive command event triggered by a user typing `/{command}` in Slack.
        /// </summary>
        slash_commands,

        /// <summary>
        /// Can be triggered by Block Kit buttons, modals, or dynamic menus
        /// </summary>
        interactive,

        /// <summary>
        /// Triggered by an event from <see href="https://api.slack.com/events">Events API</see>
        /// </summary>
        events_api,

        /// <summary>
        /// Sent when warning of an upcoming disconnect. Can have a "reason" of "warning" (10 second warning) or "refresh_requested" (immediate)
        /// </summary>
        disconnect,
    }
}
