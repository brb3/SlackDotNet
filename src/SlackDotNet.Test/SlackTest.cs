using SlackDotNet.Webhooks;
using Xunit;

namespace SlackDotNet.Test
{
    public class SlackTest
    {
        [Fact]
        public void TestWebhookValidator()
        {
            var slackClient = new Slack("12345", "67890", "ABCDE");
            var validWebhookMessage = new WebhookMessage()
            {
                Token = "ABCDE"
            };
            var invalidWebhookMessage = new WebhookMessage()
            {
                Token = "FGHIJ"
            };

            Assert.True(slackClient.ValidWebhookMessage(validWebhookMessage));
            Assert.False(slackClient.ValidWebhookMessage(invalidWebhookMessage));
        }
    }
}
