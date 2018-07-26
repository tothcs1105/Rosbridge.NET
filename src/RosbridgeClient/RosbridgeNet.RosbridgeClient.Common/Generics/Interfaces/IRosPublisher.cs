namespace RosbridgeNet.RosbridgeClient.Common.Generics.Interfaces
{
    using System.Threading.Tasks;

    public interface IRosPublisher<TRosMessage> : IRosTopicOperator<TRosMessage> where TRosMessage : class, new()
    {
        Task AdvertiseAsync();

        Task UnadvertiseAsync();

        Task PublishAsync(TRosMessage rosMessage);
    }
}
