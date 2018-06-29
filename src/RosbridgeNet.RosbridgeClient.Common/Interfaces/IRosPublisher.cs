namespace RosbridgeNet.RosbridgeClient.Common.Interfaces
{
    using System.Threading.Tasks;

    public interface IRosPublisher<TRosMessage> : IRosTopicUser<TRosMessage> where TRosMessage : class, new()
    {
        Task AdvertiseAsync();

        Task UnadvertiseAsync();

        Task PublishAsync(TRosMessage rosMessage);
    }
}
