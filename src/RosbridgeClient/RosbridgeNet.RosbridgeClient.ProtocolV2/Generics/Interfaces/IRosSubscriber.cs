namespace RosbridgeNet.RosbridgeClient.ProtocolV2.Generics.Interfaces
{
    using RosbridgeNet.RosbridgeClient.ProtocolV2.Generics.Delegates;
    using RosbridgeNet.RosbridgeClient.ProtocolV2.Interfaces;

    public interface IRosSubscriber<TRosMessage> : IRosSubscriber
    {
        new event RosMessageReceivedHanlder<TRosMessage> RosMessageReceived;
    }
}
