using SlackDotNet.Services;
using SlackDotNet.Webhooks;

namespace SlackDotNet
{
    public interface ISlack
    {
        IUsers Users {get; set; }
        IChat Chat {get; set; }
        bool ValidWebhookMessage(WebhookMessage webhookMessage);
    }
}