namespace SlackDotNet.Services
{
    public abstract class SlackService
    {
        protected SlackConfig Config;

        public SlackService(SlackConfig slackConfig)
        {
            Config = slackConfig;
        }
    }
}