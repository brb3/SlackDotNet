using SlackDotNet.Webhooks;
using SlackDotNet.Services;

namespace SlackDotNet
{
    public class Slack : ISlack
    {
        public SlackConfig Config { get; set; }
        public IChat Chat { get; set; }
        public IUsers Users { get; set; }

        public Slack(SlackConfig config, IChat slackChat, IUsers slackUsers)
        {
            Config = config;
            Chat = slackChat;
            Users = slackUsers;
        }

        /// <summary>
        /// Verifies the authenticity of a webhook message from Slack.
        /// Should be used before acting on a webhook.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ValidWebhookMessage(WebhookMessage model)
        {
            return model.Token == Config.VerificationToken;
        }
    }
}