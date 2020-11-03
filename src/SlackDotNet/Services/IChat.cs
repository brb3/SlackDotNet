using System.Threading.Tasks;
using SlackDotNet.Payloads;

namespace SlackDotNet.Services
{
    public interface IChat
    {
        Task<Responses.Chat> Delete(string channel, string ts, bool asUser);
        Task<Responses.Chat> DeleteScheduledMessage(string channel, string scheduledMessageId, bool asUser);
        Task<string> GetPermalink(string channel, string ts);
        Task<Responses.Chat> MeMessage(string channel, string text);
        Task<Responses.Chat> PostEphemeral(ChatMessage message);
        Task<Responses.Chat> PostMessage(ChatMessage message, bool ephemeral);
        Task<Responses.Chat> ScheduleMessage(ChatMessage message);
        Task<Responses.Chat> Update(ChatMessage message);
    }
}