namespace RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.RosOperations
{
    using System.Runtime.Serialization;

    [DataContract]
    public class RosPublishMessage<TRosMessage> : RosTopicMessageBase where TRosMessage : class, new()
    {
        [DataMember(Name = "msg", IsRequired = true)]
        public TRosMessage Message { get; set; }

        public RosPublishMessage() : base("publish")
        {
        }
    }
}
