namespace RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.RosbridgeStatus
{
    using System.Runtime.Serialization;

    [DataContract]
    public sealed class StatusLevelMessage : SetStatusLevelMessage
    {
        [DataMember(Name = "msg", IsRequired = true)]
        public string Message { get; set; }

        public StatusLevelMessage() : base("status")
        {
        }
    }
}
