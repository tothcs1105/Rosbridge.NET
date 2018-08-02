namespace RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.Authentication
{
    using Newtonsoft.Json;

    /// <summary>
    /// A claws to send Rosbridge authentication credentials.
    /// </summary>
    [JsonObject]
    public sealed class AuthenticateMessage : RosbridgeMessageBase
    {
        /// <summary>
        /// Gets or sets the MAC (hashed) string given by the client.
        /// </summary>
        [JsonProperty(PropertyName = "mac", Required = Required.Always)]
        public string MacAddress { get; set; }

        /// <summary>
        /// Gets or sets the IP of the client.
        /// </summary>
        [JsonProperty(PropertyName = "client", Required = Required.Always)]
        public string ClientIpAddress { get; set; }

        /// <summary>
        /// Gets or sets the IP of the destination.
        /// </summary>
        [JsonProperty(PropertyName = "dest", Required = Required.Always)]
        public string DestinationIpAddress { get; set; }

        /// <summary>
        /// Gets or sets a random string given by the client.
        /// </summary>
        [JsonProperty(PropertyName = "rand", Required = Required.Always)]
        public string Random { get; set; }

        /// <summary>
        /// Gets or sets the user level as a string given by the client.
        /// </summary>
        [JsonProperty(PropertyName = "level", Required = Required.Always)]
        public string UserLevel { get; set; }

        /// <summary>
        /// Gets or sets the time of the authorization request.
        /// </summary>
        [JsonProperty(PropertyName = "t", Required = Required.Always)]
        public int AuthorizaionTime { get; set; }

        /// <summary>
        /// Gets or sets the end time of the client's session.
        /// </summary>
        [JsonProperty(PropertyName = "end", Required = Required.Always)]
        public int ClientEndTime { get; set; }

        public AuthenticateMessage() : base("auth")
        {
        }
    }
}
