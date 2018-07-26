namespace RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.RosOperations
{
    using System.Runtime.Serialization;

    [DataContract]
    public abstract class RosMessageBase : RosbridgeMessageBase
    {
        [DataMember(Name = "id", IsRequired = false)]
        public string Id { get; set; }

        protected RosMessageBase(string operation) : base(operation)
        {
        }
    }
}
