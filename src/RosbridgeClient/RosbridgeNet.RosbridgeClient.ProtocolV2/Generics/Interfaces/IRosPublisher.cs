namespace RosbridgeNet.RosbridgeClient.ProtocolV2.Generics.Interfaces
{
    using System.Threading.Tasks;
    using RosbridgeNet.RosbridgeClient.ProtocolV2.Interfaces;

    public interface IRosPublisher<TRosMessage> : IRosPublisher where TRosMessage : class, new()
    {
        Task PublishAsync(TRosMessage rosMessage);
    }
}
