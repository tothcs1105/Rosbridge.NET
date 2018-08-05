namespace RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.RosOperations
{
    using Newtonsoft.Json;

    /// <summary>
    /// A class that indicates to ROS that you wish to unsubscribe from a specific topic.
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public sealed class UnsubscribeMessage : TopicMessageBase
    {
        public UnsubscribeMessage() : base("unsubscribe")
        {
        }
    }
}
