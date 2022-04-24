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
            .Build();

        var provider = new ServiceCollection()
            .AddLogging()
            .AddSlackDotNet(config.GetSection("SlackDotNet"))
            .BuildServiceProvider();

        var socket = provider.GetRequiredService<ISlackSocket>();

        Assert.IsType<SlackSocket>(socket);
    }
}
