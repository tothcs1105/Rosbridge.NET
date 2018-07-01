namespace RosbridgeNet.RosbridgeClient.ProtocolV2.Generics.Interfaces
{
    public interface IRosPublisher<TRosMessage> : Common.Generics.Interfaces.IRosPublisher<TRosMessage>
        where TRosMessage : class, new()
    {
    }
}
