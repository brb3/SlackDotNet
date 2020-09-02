using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using SlackDotNet.Responses;

namespace SlackDotNet.Services
{
    public class Users : SlackService, IUsers
    {
        private string UrlBase = "https://slack.com/api/users";

        public Users(SlackConfig slackConfig) : base(slackConfig) { }

        /// <summary>
        /// Gets a slack user's information
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<User> GetUser(string userId)
        {
            var response = await $"{UrlBase}.info"
                .SetQueryParam("token", Config.OauthToken)
                .SetQueryParam("user", userId)
                .GetJsonAsync<Response>();
            
            return response.User;
        }

    }
}