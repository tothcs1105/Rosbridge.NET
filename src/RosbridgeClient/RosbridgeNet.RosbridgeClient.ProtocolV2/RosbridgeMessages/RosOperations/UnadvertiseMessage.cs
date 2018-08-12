namespace RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.RosOperations
{
    using Newtonsoft.Json;

    /// <summary>
    /// A class that indicates to ROS that you won't advertise any message in a specific topic no more.
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public sealed class UnadvertiseMessage : TopicMessageBase
    {
        public UnadvertiseMessage() : base("unadvertise")
        {
        }
    }
}
