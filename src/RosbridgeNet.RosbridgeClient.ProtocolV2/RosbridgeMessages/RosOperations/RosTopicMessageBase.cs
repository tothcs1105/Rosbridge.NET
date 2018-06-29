namespace RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.RosOperations
{
    using System.Runtime.Serialization;

    [DataContract]
    public abstract class RosTopicMessageBase : RosMessageBase
    {
        [DataMember(Name = "topic", IsRequired = true)]
        public string Topic { get; set; }

        protected RosTopicMessageBase(string operation) : base(operation)
        {
        }
    }
}
