namespace RosbridgeNet.RosbridgeClient.ProtocolV2
{
    using Newtonsoft.Json.Linq;
    using RosbridgeNet.RosbridgeClient.Common;
    using RosbridgeNet.RosbridgeClient.Common.Interfaces;
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
            JArray arguments = null;

            if (serviceArgs != null)
            {
                arguments = JArray.FromObject(serviceArgs);
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

        protected override object HandleRosbridgeMessage(JObject rosbridgeMessage, string serviceName = null)
        {
            string serviceToReceiveFrom = serviceName ?? this.ServiceName;

            ServiceResponseMessage serviceResponse = rosbridgeMessage.ToObject<ServiceResponseMessage>();

            if (serviceResponse != null && serviceResponse.Service.Equals(serviceToReceiveFrom) && this.MessageId.Equals(serviceResponse.Id))
            {
                if (serviceResponse.Values != null)
                {
                    object responseObject = serviceResponse.Values.ToObject<object>();

                    return responseObject;
                }
            }

            return null;
        }

        public string MessageId { get; set; }

        public MessageCompressionLevel? MessageCompressionLevel { get; set; }

        public int? FragmentSize { get; set; }
    }
}
