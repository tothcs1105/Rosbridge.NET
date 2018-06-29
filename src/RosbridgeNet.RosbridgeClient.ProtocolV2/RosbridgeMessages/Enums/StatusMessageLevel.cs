namespace RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.Enums
{
    using System.Runtime.Serialization;

    [DataContract]
    public enum StatusMessageLevel
    {
        [EnumMember(Value = "none")]
        None = 0,

        [EnumMember(Value = "error")]
        Error = 1,

        [EnumMember(Value = "warning")]
        Warning = 2,

        [EnumMember(Value = "info")]
        Info = 3
    }
}
