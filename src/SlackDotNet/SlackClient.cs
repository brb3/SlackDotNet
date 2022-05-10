using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SlackDotNet.Models;
using SlackDotNet.Models.Messages;
using SlackDotNet.Models.Responses;

namespace SlackDotNet
{
    public class SlackClient : ISlackClient
    {
        private SlackOptions Options { get; set; }

        private ILogger<SlackClient> Logger { get; set; }

        private List<User> Users { get; set; } = null;

        public SlackClient(IOptions<SlackOptions> options, ILogger<SlackClient> logger)
        {
            Options = options.Value;
            Logger = logger;
        }

        public async Task<User> GetUser(string userId)
        {
            var response = await "https://slack.com/api/users.info"
                .SetQueryParam("token", Options.OauthToken)
                .SetQueryParam("user", userId)
                .GetJsonAsync<Response>();

            return response.User;
        }

        public async Task<bool> PostMessage(ChatMessage message, bool ephemeral = false)
        {
            var endpoint = ephemeral ? "postEphemeral" : "postMessage";
            var response = await $"https://slack.com/api/chat.{endpoint}"
                .WithHeader("Authorization", "Bearer " + Options.OauthToken)
                .PostJsonAsync(message);

            return true;
        }

        public async Task<bool> DeleteResponse(string responseUrl)
        {
            var response = await responseUrl
                .WithHeader("Authorization", "Bearer " + Options.OauthToken)
                .PostJsonAsync(new
                {
                    delete_original = true
                });

            return true;
        }

        public async Task<string> GetUserId(string username)
        {
            await RefreshUserList();
            return Users.Find(u => u.Profile.DisplayName == username).Id;
        }

        public async Task<Emojis> GetEmojisAndUrls()
        {
            var response = await $"https://slack.com/api/emoji.list"
                .WithHeader("Authorization", "Bearer " + Options.OauthToken)
                .GetJsonAsync<Emojis>();

            return response;
        }

        /// <summary>
        /// Refreshes the user list.
        ///
        /// This is rate limited to 50/minute so should not be called often.
        /// </summary>
        /// <returns></returns>
        private async Task RefreshUserList()
        {
            if (Users == null)
            {
                // TODO: This should be cached in some way and invalidated automatically without having to be manually called.
                var response = await "https://slack.com/api/users.list"
                    .WithHeader("Authorization", "Bearer " + Options.OauthToken)
                    .GetJsonAsync<UsersListResponse>();

                Users = response.Members;
            }
        }
    }
}
