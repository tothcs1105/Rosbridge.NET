namespace RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.RosOperations
{
    using System.Runtime.Serialization;

    [DataContract]
    public sealed class RosPublishMessage : RosTopicMessageBase
    {
        [DataMember(Name = "msg", IsRequired = true)]
        public object Message { get; set; }

        public RosPublishMessage() : base("publish")
        {
        }
    }
}
