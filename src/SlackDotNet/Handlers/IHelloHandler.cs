using System.Threading.Tasks;
using SlackDotNet.Models.Messages;

namespace SlackDotNet.Handlers
{
    public interface IHelloHandler
    {
        Task Handle(HelloMessage helloMessage);
    }
}
