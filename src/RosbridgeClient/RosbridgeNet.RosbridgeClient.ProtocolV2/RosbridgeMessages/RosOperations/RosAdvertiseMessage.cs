namespace RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.RosOperations
{
    using System.Runtime.Serialization;

    [DataContract]
    public sealed class RosAdvertiseMessage : RosTopicMessageBase
    {
        [DataMember(Name = "type", IsRequired = true)]
        public string Type { get; set; }

        public RosAdvertiseMessage() : base("advertise")
        {
        }
    }
}
