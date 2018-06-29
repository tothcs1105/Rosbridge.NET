namespace RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.Enums
{
    using System.Runtime.Serialization;

    [DataContract]
    public enum MessageCompressionLevel
    {
        [EnumMember(Value = "none")]
        None = 0,

        [EnumMember(Value = "png")]
        PNG = 1
    }
}
