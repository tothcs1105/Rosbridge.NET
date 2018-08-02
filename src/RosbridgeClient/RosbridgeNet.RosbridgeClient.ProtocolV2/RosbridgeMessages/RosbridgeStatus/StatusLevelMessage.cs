namespace RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.RosbridgeStatus
{
    using Newtonsoft.Json;

    /// <summary>
    /// Rosbridge status message about the successes and failures of Rosbridge protocol commands.
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public sealed class StatusLevelMessage : SetStatusLevelMessage
    {
        /// <summary>
        /// Gets or sets the Rosbridge status message.
        /// </summary>
        [JsonProperty(PropertyName = "msg", Required = Required.Always)]
        public string Message { get; set; }

        public StatusLevelMessage() : base("status")
        {
        }
    }
}
