namespace RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.RosOperations
{
    using Newtonsoft.Json;

    /// <summary>
    /// The base class for the ROS operation message classes.
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public abstract class RosMessageBase : RosbridgeMessageBase
    {
        /// <summary>
        /// Gets or sets the ID of the message.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        protected RosMessageBase(string operation) : base(operation)
        {
        }
    }
}
