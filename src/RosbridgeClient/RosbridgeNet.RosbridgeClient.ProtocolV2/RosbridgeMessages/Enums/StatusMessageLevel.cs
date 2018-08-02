namespace RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.Enums
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Rosbridge protocol command status levels.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum StatusMessageLevel
    {
        /// <summary>
        /// Whenever a user sends a message that is invalid or requests something that does not exist (ie. Sending an incorrect opcode or publishing to a topic that doesn't exist).
        /// </summary>
        [EnumMember(Value = "error")]
        Error = 0,

        /// <summary>
        /// Error, plus, whenever a user does something that may succeed but the user has still done something incorrectly (ie. Providing a partially-complete published message).
        /// </summary>
        [EnumMember(Value = "warning")]
        Warning = 1,

        /// <summary>
        /// Warning, plus messages indicating success of various operations.
        /// </summary>
        [EnumMember(Value = "info")]
        Info = 2
    }
}
