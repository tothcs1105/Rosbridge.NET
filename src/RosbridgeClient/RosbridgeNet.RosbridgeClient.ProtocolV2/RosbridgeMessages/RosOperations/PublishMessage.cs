namespace RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.RosOperations
{
    using Newtonsoft.Json;

    /// <summary>
    /// A class that contains the message that you want to publish to a ROS topic.
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public sealed class PublishMessage : TopicMessageBase
    {
        /// <summary>
        /// Gets or sets the message you want to publish.
        /// </summary>
        [JsonProperty(PropertyName = "msg", Required = Required.Always)]
        public object Message { get; set; }

        public PublishMessage() : base("publish")
        {
        }
    }
}
