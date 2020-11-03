using System.Threading.Tasks;
using Flurl.Http;
using SlackDotNet.Payloads;

namespace SlackDotNet.Services
{
    public class Chat : SlackService, IChat
    {
        public Chat(SlackConfig slackConfig) : base(slackConfig) { }
        private string UrlBase = "https://slack.com/api/chat";

        /// <summary>
        /// Sends a message to a channel.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task<Responses.Chat> PostMessage(ChatMessage message, bool ephemeral = false)
        {
            var endpoint = ephemeral ? "Ephemeral" : "Message";
            return await GetAuthorizedRequest($"{UrlBase}.post{endpoint}")
                .PostJsonAsync(message)
                .ReceiveJson<Responses.Chat>();
        }

        /// <summary>
        /// Deletes a message
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="ts"></param>
        /// <param name="asUser"></param>
        /// <returns></returns>
        public async Task<Responses.Chat> Delete(string channel, string ts, bool asUser = false)
        {
            return await GetAuthorizedRequest($"{UrlBase}.delete")
                .PostJsonAsync(new
                {
                    channel = channel,
                    ts = ts,
                    as_user = asUser
                })
                .ReceiveJson<Responses.Chat>();
        }

        /// <summary>
        /// Deletes a pending scheduled message from the queue. 
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="scheduledMessageId"></param>
        /// <param name="asUser"></param>
        /// <returns></returns>
        public async Task<Responses.Chat> DeleteScheduledMessage(string channel, string scheduledMessageId, bool asUser)
        {
            return await GetAuthorizedRequest($"{UrlBase}.deleteScheduledMessage")
                .PostJsonAsync(new
                {
                    channel = channel,
                    scheduled_message_id = scheduledMessageId,
                    as_user = asUser
                })
                .ReceiveJson<Responses.Chat>();
        }

        /// <summary>
        /// Retrieve a permalink URL for a specific extant message
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        public async Task<string> GetPermalink(string channel, string ts)
        {
            var response = await GetAuthorizedRequest($"{UrlBase}.getPermalink")
                .SetQueryParams(new
                {
                    channel = channel,
                    message_ts = ts
                })
                .GetJsonAsync<Responses.Chat>();
            
            return response.Ok ? response.Permalink : null; 
        }

        /// <summary>
        /// Share a me message into a channel.
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public async Task<Responses.Chat> MeMessage(string channel, string text)
        {
            return await GetAuthorizedRequest($"{UrlBase}.meMessage")
                .PostJsonAsync(new {
                    channel = channel,
                    text = text
                })
                .ReceiveJson<Responses.Chat>();
        }

        /// <summary>
        /// Sends an ephemeral message to a user in a channel.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task<Responses.Chat> PostEphemeral(ChatMessage message)
        {
            return await PostMessage(message, true);
        }

        /// <summary>
        /// Schedules a message to be sent to a channel.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task<Responses.Chat> ScheduleMessage(ChatMessage message)
        {
            return await GetAuthorizedRequest($"{UrlBase}.scheduleMessage")
                .PostJsonAsync(message)
                .ReceiveJson<Responses.Chat>();
        }

        /// <summary>
        /// Updates a message.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task<Responses.Chat> Update(ChatMessage message)
        {
            return await GetAuthorizedRequest($"{UrlBase}.update")
                .PostJsonAsync(message)
                .ReceiveJson<Responses.Chat>();
        }
    }
}