namespace RosbridgeNet.RosbridgeClient.ProtocolV2
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using RosbridgeNet.RosbridgeClient.Common;
    using RosbridgeNet.RosbridgeClient.Common.Interfaces;
    using RosbridgeNet.RosbridgeClient.ProtocolV2.Exceptions;
    using RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.Enums;
    using RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.RosOperations;
    using IRosServiceClient = RosbridgeNet.RosbridgeClient.ProtocolV2.Interfaces.IRosServiceClient;

    public class RosServiceClient : RosServiceClientBase<CallServiceMessage>, IRosServiceClient
    {
        public RosServiceClient(IRosbridgeMessageDispatcher rosbridgeMessageDispatcher, string serviceName = null) : base(rosbridgeMessageDispatcher, serviceName)
        {
        }

        protected override CallServiceMessage CreateServiceCallMessage(object serviceArgs = null, string serviceName = null)
        {
            JToken arguments = null;

            if (serviceArgs != null)
            {
                arguments = JToken.FromObject(serviceArgs);
            }

            string serviceToCall = serviceName ?? this.ServiceName;

            return new CallServiceMessage()
            {
                Arguments = arguments,
                Compression = this.MessageCompressionLevel,
                FragmentSize = this.FragmentSize,
                Id = this.MessageId,
                Service = serviceToCall
            };
        }

        protected override bool HandleRosbridgeMessage(JObject rosbridgeMessage, ref JObject rosMessage, string serviceName = null)
        {
            string serviceToReceiveFrom = serviceName ?? this.ServiceName;

            ServiceResponseMessage serviceResponse = null;

            try
            {
                serviceResponse = rosbridgeMessage.ToObject<ServiceResponseMessage>();
            }
            catch (JsonSerializationException e)
            {
            }

            if (serviceResponse != null && object.Equals(serviceResponse.Service, serviceToReceiveFrom) && object.Equals(this.MessageId, serviceResponse.Id))
            {
                if (serviceResponse.Values != null)
                {
                    if (serviceResponse.Values.Type == JTokenType.Object)
                    {
                        if (serviceResponse.Values.HasValues)
                        {
                            JObject responseObject = (JObject)serviceResponse.Values;

                            rosMessage = responseObject;
                        }

                        return true;
                    }
                    else if (serviceResponse.Values.Type == JTokenType.String)
                    {
                        throw new RosServiceException(serviceResponse.Values.ToString());
                    }
                }
            }

            return false;
        }

        public string MessageId { get; set; }

        public MessageCompressionLevel? MessageCompressionLevel { get; set; }

        public int? FragmentSize { get; set; }
    }
}
