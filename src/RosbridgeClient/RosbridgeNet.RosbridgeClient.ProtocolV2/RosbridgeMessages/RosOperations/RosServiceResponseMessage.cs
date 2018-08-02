namespace RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.RosOperations
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// A class that contains information about a ROS service response.
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public sealed class RosServiceResponseMessage : RosMessageBase
    {
        /// <summary>
        /// Gets or sets the name of the service that was called.
        /// </summary>
        [JsonProperty(PropertyName = "service", Required = Required.Always)]
        public string Service { get; set; }

        /// <summary>
        /// Gets or sets the values that was provided by the service.
        /// </summary>
        [JsonProperty(PropertyName = "values")]
        public JArray Values { get; set; }

        public RosServiceResponseMessage() : base("service_response")
        {
        }
    }
}
