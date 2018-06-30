namespace RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.RosOperations
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json.Linq;

    [DataContract]
    public sealed class RosServiceResponseMessage : RosMessageBase
    {
        [DataMember(Name = "service", IsRequired = true)]
        public string Service { get; set; }

        [DataMember(Name = "values", IsRequired = false)]
        public JArray ValueList { get; set; }

        public RosServiceResponseMessage() : base("service_response")
        {
        }
    }
}
