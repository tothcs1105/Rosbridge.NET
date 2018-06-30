namespace RosbridgeNet.RosbridgeClient.ProtocolV2.Interfaces
{
    using RosbridgeNet.RosbridgeClient.Common.Interfaces;
    using RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.RosOperations;

    public interface IRosSubscriberV2<TRosMessage> : IRosSubscriber<TRosMessage> where TRosMessage : class, new()
    {
        RosSubscribeMessage RosSubscribeMessage { get; }

        RosUnsubscribeMessage RosUnsubscribeMessage { get; }
    }
}
