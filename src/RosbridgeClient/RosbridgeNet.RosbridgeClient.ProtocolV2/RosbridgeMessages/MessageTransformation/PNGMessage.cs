namespace RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.MessageTransformation
{
    using Newtonsoft.Json;

    /// <summary>
    /// Class for using Rosbridge PNG compression. Some messages (such as point clouds) can be extremely large, and for efficiency reasons we may wish to transfer them as PNG-encoded bytes. 
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public sealed class PngMessage : RosbridgeMessageBase
    {
        /// <summary>
        /// Gets or sets the message ID. Only required if the message is fragmented. Identifies the fragments for the fragmented message.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets a fragment of a PNG-encoded message or an entire message.
        /// </summary>
        [JsonProperty(PropertyName = "data", Required = Required.Always)]
        public string Data { get; set; }

        /// <summary>
        /// Gets or sets the index of the fragment. Only required if the message is fragmented.
        /// </summary>
        [JsonProperty(PropertyName = "num")]
        public int? Number { get; set; }

        /// <summary>
        /// Gets or sets the total number of fragments. Only required if the message is fragmented.
        /// </summary>
        [JsonProperty(PropertyName = "total")]
        public int? Total { get; set; }

        public PngMessage() : base("png")
        {
        }
    }
}
