using SlackDotNet.Models.Messages.Payloads.EventsAPI;
using SlackDotNet.Models.Messages.Payloads.Interactive;

namespace SlackDotNet.Enums
{
    public enum InteractiveMessageType
    {
        block_actions,

        shortcut,

        message_actions,

        [Type(typeof(ViewSubmission))]
        view_submission,

        view_closed
    }
}
