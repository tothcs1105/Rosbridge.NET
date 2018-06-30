namespace RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.MessageTransformation
{
    using System.Runtime.Serialization;

    [DataContract]
    public sealed class FragmentedMessage : RosbridgeMessageBase
    {
        [DataMember(Name = "id", IsRequired = true)]
        public string Id { get; set; }

        [DataMember(Name = "data", IsRequired = true)]
        public string Data { get; set; }

        [DataMember(Name = "num", IsRequired = true)]
        public int Number { get; set; }

        [DataMember(Name = "total", IsRequired = true)]
        public int Total { get; set; }

        public FragmentedMessage() : base("fragment")
        {
        }
    }
}
