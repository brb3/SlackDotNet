using System.Threading.Tasks;
using SlackDotNet.Models;
using SlackDotNet.Models.Messages;
using SlackDotNet.Models.Responses;

namespace SlackDotNet
{
    public interface ISlackClient
    {
        /// <summary>
        /// Get's a slack user's information
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<User> GetUser(string userId);

        /// <summary>
        /// Posts a message to a channel
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        Task<bool> PostMessage(ChatMessage message, bool ephemeral = false);

        /// <summary>
        /// Deletes a message in response to an interactive command
        /// </summary>
        /// <param name="responseUrl"></param>
        /// <returns></returns>
        Task<bool> DeleteResponse(string responseUrl);

        /// <summary>
        /// Get's the user's ID from their username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<string> GetUserId(string username);

        /// <summary>
        /// Get's all the emojis in the workspace as a dictionary of name => URL
        /// </summary>
        /// <returns></returns>
        Task<Emojis> GetEmojisAndUrls();
    }
}
