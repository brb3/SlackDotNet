using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackDotNet.Models.Responses
{
    public class UsersListResponse
    {
        [JsonProperty("ok")]
        public bool Ok { get; set; }

        [JsonProperty("members")]
        public List<User> Members { get; set; }
    }
}
