namespace RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.Authentication
{
    using System.Runtime.Serialization;

    [DataContract]
    public sealed class AuthenticateMessage : RosbridgeMessageBase
    {
        [DataMember(Name = "mac", IsRequired = true)]
        public string MacAddress { get; set; }

        [DataMember(Name = "client", IsRequired = true)]
        public string ClientIPAddress { get; set; }

        [DataMember(Name = "dest", IsRequired = true)]
        public string DestinationIPAddress { get; set; }

        [DataMember(Name = "rand", IsRequired = true)]
        public string Random { get; set; }

        [DataMember(Name = "level", IsRequired = true)]
        public string UserLevel { get; set; }

        [DataMember(Name = "t", IsRequired = true)]
        public int AuthorizaionTime { get; set; }

        [DataMember(Name = "end", IsRequired = true)]
        public int ClientEndTime { get; set; }

        public AuthenticateMessage() : base("auth")
        {
        }
    }
}
