namespace SlackDotNet.SampleApp
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using SlackDotNet;
    using System;
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.local.json", true);

            var configuration = configurationBuilder.Build();

            var slackToken = configuration["Slack:AppLevelToken"];

            Console.WriteLine(slackToken);

            // var serviceProvider = new ServiceCollection()
            //     .AddSlackDotNet(slackConfig)
            //     .BuildServiceProvider();
        }
    }
}
