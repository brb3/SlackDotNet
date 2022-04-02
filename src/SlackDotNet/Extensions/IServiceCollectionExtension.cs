namespace SlackDotNet.Extensions
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class IServiceCollectionExtension
    {
        /// <summary>
        /// Adds the SlackDotNet services to the IServiceCollection.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configurationSection"></param>
        /// <returns></returns>
        public static IServiceCollection AddSlackDotNet(this IServiceCollection services, IConfigurationSection configurationSection)
        {
            services.Configure<SlackOptions>(o => configurationSection.Bind(o));
            services.AddSingleton<ISlackSocket, SlackSocket>();
            return services;
        }
    }
}
