namespace RosbridgeNet.RosbridgeClient.Common.Interfaces
{
    using System.Threading.Tasks;

    public interface IRosPublisher : IRosTopicOperator
    {
        Task AdvertiseAsync();

        Task UnadvertiseAsync();

        Task PublishAsync(object rosMessage);
    }
}
