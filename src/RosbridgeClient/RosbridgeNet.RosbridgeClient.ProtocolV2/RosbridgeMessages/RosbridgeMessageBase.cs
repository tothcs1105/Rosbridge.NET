namespace RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages
{
    using System.Runtime.Serialization;

    [DataContract]
    public abstract class RosbridgeMessageBase
    {
        [DataMember(Name = "op", IsRequired = true)]
        public string Operation { get; private set; }

        protected RosbridgeMessageBase(string operation)
        {
            Operation = operation;
        }
    }
}
