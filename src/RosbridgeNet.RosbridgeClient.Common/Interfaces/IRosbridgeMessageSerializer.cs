namespace RosbridgeNet.RosbridgeClient.Common.Interfaces
{
    using Newtonsoft.Json.Linq;

    public interface IRosbridgeMessageSerializer
    {
        byte[] Serialize<TMessage>(TMessage message) where TMessage : class, new();

        JObject Deserialize(byte[] serializedMessage);
    }
}
