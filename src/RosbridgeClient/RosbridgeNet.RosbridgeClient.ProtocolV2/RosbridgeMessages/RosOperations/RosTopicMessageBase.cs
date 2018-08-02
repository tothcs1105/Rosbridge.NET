namespace RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.RosOperations
{
    using Newtonsoft.Json;

    /// <summary>
    /// A base class for topic based ROS operations.
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public abstract class RosTopicMessageBase : RosMessageBase
    {
        /// <summary>
        /// Gets or sets the ROS topic.
        /// </summary>
        [JsonProperty(PropertyName = "topic", Required = Required.Always)]
        public string Topic { get; set; }

        protected RosTopicMessageBase(string operation) : base(operation)
        {
        }
    }
}
