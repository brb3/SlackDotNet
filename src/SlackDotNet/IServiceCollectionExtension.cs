using Microsoft.Extensions.DependencyInjection;
using SlackDotNet.Services;

namespace SlackDotNet
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddSlackDotNet(this IServiceCollection services, SlackConfig slackConfig)
        {
            services.AddSingleton<SlackConfig>(slackConfig);
            services.AddSingleton<IChat, Chat>();
            services.AddSingleton<IUsers, Users>();
            services.AddSingleton<ISlack, Slack>();
            return services;
        }
    }
}