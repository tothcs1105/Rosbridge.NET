namespace RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.Enums
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// The compression scheme types, which can be used on a messages.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MessageCompressionLevel
    {
        [EnumMember(Value = "none")]
        None = 0,

        [EnumMember(Value = "png")]
        PNG = 1
    }
}
