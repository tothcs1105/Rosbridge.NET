namespace RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.RosOperations
{
    using Enums;
    using Newtonsoft.Json;

    /// <summary>
    /// A class that indicates to ROS that you wish to subscribe to a specific topic.
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public sealed class SubscribeMessage : TopicMessageBase
    {
        /// <summary>
        /// Gets or sets the type of the message used in the topic.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the minimum amount of time (in ms) that must elapse between messages being sent. Defaults to 0.
        /// </summary>
        [JsonProperty(PropertyName = "throttle_rate")]
        public int? ThrottleRate { get; set; }

        /// <summary>
        /// Gets or sets the size of the queue to buffer messages. Messages are buffered as a result of the throttle_rate. Defaults to 1.
        /// </summary>
        [JsonProperty(PropertyName = "queue_length")]
        public int? QueueLength { get; set; }

        /// <summary>
        /// Gets or sets the maximum size that a message can take before it is to be fragmented.
        /// </summary>
        [JsonProperty(PropertyName = "fragment_size")]
        public int? FragmentSize { get; set; }

        /// <summary>
        /// Gets or sets the compression scheme to be used on messages.
        /// </summary>
        [JsonProperty(PropertyName = "compression")]
        public MessageCompressionLevel? Compression { get; set; }

        public SubscribeMessage() : base("subscribe")
        {
        }
    }
}
