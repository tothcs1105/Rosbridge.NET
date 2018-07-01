namespace RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.RosOperations
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Linq;
    using RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.Enums;

    [DataContract]
    public sealed class RosCallServiceMessage : RosMessageBase
    {
        [DataMember(Name = "service", IsRequired = true)]
        public string Service { get; set; }

        [DataMember(Name = "args", IsRequired = false)]
        public JArray Arguments { get; set; }

        [DataMember(Name = "fragment_size", IsRequired = false)]
        public int? FragmentSize { get; set; }

        [DataMember(Name = "compression", IsRequired = false)]
        [JsonConverter(typeof(StringEnumConverter))]
        public MessageCompressionLevel? Compression { get; set; }

        public RosCallServiceMessage() : base("call_service")
        {
        }
    }
}
