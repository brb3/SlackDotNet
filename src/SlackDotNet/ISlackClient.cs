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
        /// Gets the user's ID from their display name
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<string> GetUserId(string username);

        /// <summary>
        /// Gets the user's display name from their username
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<string> GetUserName(string userId);

        /// <summary>
        /// Get's all the emojis in the workspace as a dictionary of name => URL
        /// </summary>
        /// <returns></returns>
        Task<Emojis> GetEmojisAndUrls();

        /// <summary>
        /// Publish a view.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<PublishViewResponse> PublishView(PublishViewRequest request);
    }
}
