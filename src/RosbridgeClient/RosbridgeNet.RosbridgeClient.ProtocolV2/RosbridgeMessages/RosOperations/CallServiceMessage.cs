namespace RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.RosOperations
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.Enums;

    /// <summary>
    /// A class that contains the required information to call a ROS service.
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public sealed class CallServiceMessage : RosMessageBase
    {
        /// <summary>
        /// Gets or sets the name of the service to call.
        /// </summary>
        [JsonProperty(PropertyName = "service", Required = Required.Always)]
        public string Service { get; set; }

        /// <summary>
        /// Gets or sets the args required by the service.
        /// </summary>
        [JsonProperty(PropertyName = "args")]
        public JToken Arguments { get; set; }

        /// <summary>
        /// Gets or sets the maximum size that the response message can take before it is fragmented.
        /// </summary>
        [JsonProperty(PropertyName = "fragment_size")]
        public int? FragmentSize { get; set; }

        /// <summary>
        /// Gets or sets the compression scheme to be used on messages.
        /// </summary>
        [JsonProperty(PropertyName = "compression")]
        public MessageCompressionLevel? Compression { get; set; }

        public CallServiceMessage() : base("call_service")
        {
        }
    }
}
