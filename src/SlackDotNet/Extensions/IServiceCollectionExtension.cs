namespace SlackDotNet.Extensions
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;
    using SlackDotNet.Handlers;

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

            // Try to add our default implementation of the message handlers.
            // This allows a user to register their handlers first and we won't override them.
            services.TryAddSingleton<IDefaultHandler, DefaultHandler>();
            services.TryAddSingleton<ISlashCommandHandler, SlashCommandHandler>();
            services.TryAddSingleton<IHelloHandler, HelloHandler>();
            services.TryAddSingleton<IEventsAPIHandler, EventsAPIHandler>();

            services.AddSingleton<ISlackSocket, SlackSocket>();
            return services;
        }
    }
}
