namespace RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.RosbridgeStatus
{
    using Enums;
    using Newtonsoft.Json;

    /// <summary>
    /// Set the Rosbridge API status message level.
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class SetStatusLevelMessage : RosbridgeMessageBase
    {
        /// <summary>
        /// Gets or sets the id of the status message.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the status level.
        /// </summary>
        [JsonProperty(PropertyName = "level", Required = Required.Always)]
        public StatusMessageLevel StatusLevel { get; set; }

        public SetStatusLevelMessage() : base("set_level")
        {
        }

        protected SetStatusLevelMessage(string operation) : base(operation)
        {
        }
    }
}
