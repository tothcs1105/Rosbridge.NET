namespace RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.MessageTransformation
{
    using System.Runtime.Serialization;

    [DataContract]
    public sealed class PNGMessage : RosbridgeMessageBase
    {
        [DataMember(Name = "id", IsRequired = false)]
        public string Id { get; set; }

        [DataMember(Name = "data", IsRequired = true)]
        public string Data { get; set; }

        [DataMember(Name = "num", IsRequired = false)]
        public int? Number { get; set; }

        [DataMember(Name = "total", IsRequired = false)]
        public int? Total { get; set; }

        public PNGMessage() : base("png")
        {
        }
    }
}
