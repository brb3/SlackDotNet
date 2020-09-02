using System.Threading.Tasks;
using SlackDotNet.Responses;

namespace SlackDotNet.Services
{
    public interface IUsers
    {
        Task<User> GetUser(string userId);
    }
}