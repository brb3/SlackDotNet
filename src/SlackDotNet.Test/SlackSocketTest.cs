using System;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl.Http.Testing;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using SlackDotNet.Exceptions;
using SlackDotNet.Handlers;
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
        var defaultHandler = new Mock<IDefaultHandler>();
        var helloHandler = new Mock<IHelloHandler>();
        var slashCommandHandler = new Mock<ISlashCommandHandler>();

        SlackSocket = new SlackSocket(options, logger.Object, defaultHandler.Object, helloHandler.Object, slashCommandHandler.Object);
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

    /// <summary>
    /// Test that the method that checks if a message has been handled is properly
    /// caching and testing values.
    /// </summary>
    [Fact]
    public void MessageHasBeenHandledTest()
    {
        var envelopeId = "1234567890";
        var envelopeId2 = "0987654321";

        // Fake a new message
        var response = SlackSocket.MessageHasBeenHandled(envelopeId);
        Assert.False(response);

        // Test the same message again to make sure it returns "true"
        response = SlackSocket.MessageHasBeenHandled(envelopeId);
        Assert.True(response);

        // Test the same as above to make sure it wasn't purged
        response = SlackSocket.MessageHasBeenHandled(envelopeId);
        Assert.True(response);

        // Test a new value
        response = SlackSocket.MessageHasBeenHandled(envelopeId2);
        Assert.False(response);
    }
}
