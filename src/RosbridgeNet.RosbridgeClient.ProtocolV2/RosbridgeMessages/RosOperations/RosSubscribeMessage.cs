namespace RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.RosOperations
{
    using System.Runtime.Serialization;
    using Enums;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    [DataContract]
    public class RosSubscribeMessage : RosTopicMessageBase
    {
        [DataMember(Name = "type", IsRequired = false)]
        public string Type { get; set; }

        [DataMember(Name = "throttle_rate", IsRequired = false)]
        public int? ThrottleRate { get; set; }

        [DataMember(Name = "queue_length", IsRequired = false)]
        public int? QueueLength { get; set; }

        [DataMember(Name = "fragment_size", IsRequired = false)]
        public int? FragmentSize { get; set; }

        [DataMember(Name = "compression", IsRequired = false)]
        [JsonConverter(typeof(StringEnumConverter))]
        public MessageCompressionLevel? Compression { get; set; }

        public RosSubscribeMessage() : base("subscribe")
        {
        }
    }
}
