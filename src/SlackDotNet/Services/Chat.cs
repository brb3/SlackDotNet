using System.Threading.Tasks;
using Flurl.Http;
using SlackDotNet.Payloads;

namespace SlackDotNet.Services
{
    public class Chat : SlackService, IChat
    {
        public Chat(SlackConfig slackConfig) : base(slackConfig) { }
        private string UrlBase = "https://slack.com/api/chat";

        /// <summary>
        /// Posts a message to a channel
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task<bool> PostMessage(ChatMessage message, bool ephemeral = false)
        {
            var endpoint = ephemeral ? "Ephemeral" : "Message";
            var response = await $"{UrlBase}.post{endpoint}"
                .WithHeader("Authorization", "Bearer " + Config.OauthToken)
                .PostJsonAsync(message);

            return true;
        }
    }
}