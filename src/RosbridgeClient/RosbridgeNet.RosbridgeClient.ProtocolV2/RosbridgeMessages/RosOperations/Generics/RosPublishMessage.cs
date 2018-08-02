namespace RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.RosOperations.Generics
{
    using Newtonsoft.Json;

    /// <summary>
    /// A generic class that contains the message that you want to publish to a ROS topic.
    /// </summary>
    [JsonObject]
    public sealed class RosPublishMessage<TRosMessage> : RosTopicMessageBase where TRosMessage : class, new()
    {
        /// <summary>
        /// Gets or sets the message you want to publish.
        /// </summary>
        [JsonProperty(PropertyName = "msg", Required = Required.Always)]
        public TRosMessage Message { get; set; }

        public RosPublishMessage() : base("publish")
        {
        }
    }
}
