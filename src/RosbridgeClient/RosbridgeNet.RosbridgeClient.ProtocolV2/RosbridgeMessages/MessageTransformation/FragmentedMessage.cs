namespace RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.MessageTransformation
{
    using Newtonsoft.Json;

    /// <summary>
    /// A fragmented Rosbridge message.
    /// </summary>
    [JsonObject]
    public sealed class FragmentedMessage : RosbridgeMessageBase
    {
        /// <summary>
        /// Gets or sets the fragmented message ID. An id is required for fragmented messages, in order to identify corresponding fragments for the message.
        /// </summary>
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets a fragment of data that, when combined with other fragments of data, makes up another message.
        /// </summary>
        [JsonProperty(PropertyName = "data", Required = Required.Always)]
        public string Data { get; set; }

        /// <summary>
        /// Gets or sets the index of the fragment in the message.
        /// </summary>
        [JsonProperty(PropertyName = "num", Required = Required.Always)]
        public int Number { get; set; }

        /// <summary>
        /// Gets or sets the total number of fragments.
        /// </summary>
        [JsonProperty(PropertyName = "total", Required = Required.Always)]
        public int Total { get; set; }

        public FragmentedMessage() : base("fragment")
        {
        }
    }
}
