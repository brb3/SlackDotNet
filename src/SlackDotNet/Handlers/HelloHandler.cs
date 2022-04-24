using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SlackDotNet.Models.Messages;

namespace SlackDotNet.Handlers
{
    public class HelloHandler : IHelloHandler
    {
        private ILogger<HelloHandler> Logger { get; }

        public HelloHandler(ILogger<HelloHandler> logger)
        {
            Logger = logger;
        }

        public async Task Handle(HelloMessage helloMessage)
        {
            await Task.Run(() =>
                Logger.LogInformation($"Received `{helloMessage.Type}` message from WebSocket.")
            );
        }
    }
}
