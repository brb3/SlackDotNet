using System.Threading.Tasks;
using SlackDotNet.Payloads;

namespace SlackDotNet.Services
{
    public interface IChat
    {
        Task<bool> PostMessage(ChatMessage message, bool ephemeral = false);
    }
}