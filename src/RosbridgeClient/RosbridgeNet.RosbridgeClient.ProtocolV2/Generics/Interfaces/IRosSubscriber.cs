namespace RosbridgeNet.RosbridgeClient.ProtocolV2.Generics.Interfaces
{
    using RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.RosOperations;

    public interface IRosSubscriber<TRosMessage> : Common.Generics.Interfaces.IRosSubscriber<TRosMessage> where TRosMessage : class, new()
    {
        RosSubscribeMessage RosSubscribeMessage { get; }

        RosUnsubscribeMessage RosUnsubscribeMessage { get; }
    }
}
