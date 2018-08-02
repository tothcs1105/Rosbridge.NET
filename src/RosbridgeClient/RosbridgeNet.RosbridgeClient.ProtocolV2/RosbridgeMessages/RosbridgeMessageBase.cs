namespace RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages
{
    using Newtonsoft.Json;

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public abstract class RosbridgeMessageBase
    {
        [JsonProperty(PropertyName = "op", Required = Required.Always)]
        public string Operation { get; private set; }

        protected RosbridgeMessageBase(string operation)
        {
            Operation = operation;
        }
    }
}
