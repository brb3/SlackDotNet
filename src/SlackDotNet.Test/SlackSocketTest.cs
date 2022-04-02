using System;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl.Http.Testing;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using SlackDotNet.Exceptions;
using SlackDotNet.Models;
using SlackDotNet.Models.Responses;
using Xunit;

namespace SlackDotNet.Test;

public class SlackSocketTest
{
    private readonly ISlackSocket SlackSocket;
    private readonly SlackOptions SlackOptions;

    public SlackSocketTest()
    {
        var logger = new Mock<ILogger<SlackSocket>>();
        SlackOptions = new SlackOptions()
        {
            AppLevelToken = "1234567890"
        };

        var options = Options.Create<SlackOptions>(SlackOptions);

        SlackSocket = new SlackSocket(options, logger.Object);
    }

    /// <summary>
    /// Verifies that a refusal to create a socket from Slack with throw SocketConnectionException
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task GetWssUrlRequestsSocketConnectionAndIsDenied()
    {
        using (var httpTest = new HttpTest())
        {
            var connectionResponse = new Connection()
            {
                Ok = false,
            };
            httpTest.RespondWithJson(connectionResponse, 200);

            try
            {
                await SlackSocket.Connect();
            }
            catch (Exception e)
            {
                Assert.IsType<SlackApiResponseException>(e);
            }

            httpTest.ShouldHaveCalled(SlackApiEndpoints.AppConnectionsOpen)
                .WithVerb(HttpMethod.Post)
                .WithHeader("Authorization", $"Bearer {SlackOptions.AppLevelToken}");
        }
    }

    /// <summary>
    /// Verifies that an HTTP failure throws a Flurl exception
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task GetWssUrlRequestsSocketConnectionAndHTTPFails()
    {
        using (var httpTest = new HttpTest())
        {
            httpTest.RespondWithJson("Server Exception", 503);

            try
            {
                await SlackSocket.Connect();
            }
            catch (Exception e)
            {
                Assert.IsType<SlackApiResponseException>(e);
            }

            httpTest.ShouldHaveCalled(SlackApiEndpoints.AppConnectionsOpen)
                .WithVerb(HttpMethod.Post)
                .WithHeader("Authorization", $"Bearer {SlackOptions.AppLevelToken}");
        }
    }

    /// <summary>
    /// Verifies that the SlackSocket client attempts to create a connection
    ///
    /// WebSocketClient will throw an exception that should be caught and wrapped.
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task ConnectAttemptsWebSocketConnection()
    {
        using (var httpTest = new HttpTest())
        {
            var connectionResponse = new Connection()
            {
                Ok = true,
                Url = new Uri("wss://example")
            };
            httpTest.RespondWithJson(connectionResponse, 200);

            try
            {
                await SlackSocket.Connect();
            }
            catch (Exception e)
            {
                Assert.IsType<SlackSocketConnectionException>(e);
            }

            httpTest.ShouldHaveCalled(SlackApiEndpoints.AppConnectionsOpen)
                .WithVerb(HttpMethod.Post)
                .WithHeader("Authorization", $"Bearer {SlackOptions.AppLevelToken}");
        }
    }
}
