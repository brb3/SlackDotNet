using Newtonsoft.Json;

namespace SlackDotNet.Models.Messages
{
    public class HelloMessage : SlackWebSocketMessage
    {
        [JsonProperty("connection_info")]
        public ConnectionInfo ConnectionInfo { get; set; }

        /// <summary>
        /// How many connections are currently active. Appears to only be used during the `hello` message.
        /// </summary>
        [JsonProperty("num_connections")]
        public int NumberOfConnections { get; set; }

        [JsonProperty("debug_info")]
        public DebugInfo DebugInfo { get; set; }
    }
}
