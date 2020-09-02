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

        public Task<bool> Delete(string channel, string timestamp, bool asUser)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteScheduledMessage(string channel, string scheduledMessageId, bool asUser)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> GetPermalink(string channel, string timestamp)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> MeMessage(string channel, string text)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> PostEphemeral(ChatMessage message)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> PostMessage(ChatMessage message)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> ScheduleMessage(ChatMessage message)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Update(ChatMessage message)
        {
            throw new System.NotImplementedException();
        }
    }
}