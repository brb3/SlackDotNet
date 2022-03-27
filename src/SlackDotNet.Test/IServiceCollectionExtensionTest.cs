namespace SlackDotNet.Test;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SlackDotNet.Extensions;
using Xunit;

public class IServiceCollectionExtensionTest
{

    [Fact]
    public void AddSlackDotNetTest()
    {
        // Load configuration from appsettings.json
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", false, false)
            .AddJsonFile("appsettings.local.json", true, false)
            .Build();

        var services = new ServiceCollection()
            .AddSlackDotNet(config.GetSection("SlackDotNet"))
            .BuildServiceProvider();

        var slackOptions = services.GetService<SlackOptions>();
    }
}
