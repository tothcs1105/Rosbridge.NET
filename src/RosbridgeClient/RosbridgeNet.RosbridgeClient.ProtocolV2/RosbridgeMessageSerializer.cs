namespace RosbridgeNet.RosbridgeClient.ProtocolV2
{
    using System;
    using System.Text;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using RosbridgeNet.RosbridgeClient.Common.Interfaces;

    public sealed class RosbridgeMessageSerializer : IRosbridgeMessageSerializer
    {
        private const string EncodingType = "US-ASCII";

        public byte[] Serialize<TMessage>(TMessage message) where TMessage : class, new()
        {
            if (null == message)
            {
                throw new ArgumentNullException(nameof(message));
            }

            string jsonString = JsonConvert.SerializeObject(message);

            return Encoding.GetEncoding(EncodingType).GetBytes(jsonString);
        }

        public JObject Deserialize(byte[] serializedMessage)
        {
            if (null == serializedMessage)
            {
                throw new ArgumentNullException(nameof(serializedMessage));
            }

            string jsonString = Encoding.GetEncoding(EncodingType).GetString(serializedMessage, 0, serializedMessage.Length);

            return JObject.Parse(jsonString);
        }
    }
}