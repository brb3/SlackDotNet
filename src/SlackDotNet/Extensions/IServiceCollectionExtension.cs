namespace SlackDotNet.Extensions
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddSlackDotNet(this IServiceCollection services, IConfigurationSection configurationSection)
        {
            services.Configure<SlackOptions>(o => configurationSection.Bind(o));
            services.AddSingleton<ISlackSocket, SlackSocket>();
            return services;
        }
    }
}
