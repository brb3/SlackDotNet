using SlackDotNet.Webhooks;
using Xunit;
using Moq;
using SlackDotNet.Services;

namespace SlackDotNet.Test
{
    public class SlackTest
    {
        [Fact]
        public void TestWebhookValidator()
        {
            var mockChat = new Mock<IChat>();
            var mockUsers = new Mock<IUsers>();
            var slackConfig = new SlackConfig("12345", "67890", "ABCDE");
            var slackClient = new Slack(slackConfig, mockChat.Object, mockUsers.Object);
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
