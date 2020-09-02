using System.Threading.Tasks;
using SlackDotNet.Payloads;

namespace SlackDotNet.Services
{
    public interface IChat
    {
        Task<bool> Delete(string channel, string timestamp, bool asUser);
        Task<bool> DeleteScheduledMessage(string channel, string scheduledMessageId, bool asUser);
        Task<string> GetPermalink(string channel, string timestamp);
        Task<bool> MeMessage(string channel, string text);
        Task<bool> PostEphemeral(ChatMessage message);
        Task<bool> PostMessage(ChatMessage message);
        Task<bool> ScheduleMessage(ChatMessage message);
        Task<bool> Update(ChatMessage message);
    }
}