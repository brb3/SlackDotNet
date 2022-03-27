using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SlackDotNet.Extensions;

public static class IServiceCollectionExtension
{
    public static IServiceCollection AddSlackDotNet(this IServiceCollection services, IConfigurationSection configurationSection)
    {
        services.Configure<SlackOptions>(o => configurationSection.Bind(o));
        return services;
    }
}
