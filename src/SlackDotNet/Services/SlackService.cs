using Flurl.Http;

namespace SlackDotNet.Services
{
    public abstract class SlackService
    {
        protected SlackConfig Config;

        public SlackService(SlackConfig slackConfig)
        {
            Config = slackConfig;
        }

        /// <summary>
        /// Builds a request URL with the authorization header
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        protected IFlurlRequest GetAuthorizedRequest(string url)
        {
            return url.WithHeader("Authorization", "Bearer " + Config.OauthToken);
        }
    }
}