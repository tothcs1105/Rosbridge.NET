namespace RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.RosOperations
{
    using Newtonsoft.Json;

    /// <summary>
    /// A class that indicates to ROS that you wish to advertise a message in a specific topic.
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public sealed class AdvertiseMessage : TopicMessageBase
    {
        /// <summary>
        /// Gets or sets the type of the message.
        /// </summary>
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        public string Type { get; set; }

        public AdvertiseMessage() : base("advertise")
        {
        }
    }
}
