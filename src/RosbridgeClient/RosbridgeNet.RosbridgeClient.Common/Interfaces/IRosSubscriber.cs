namespace RosbridgeNet.RosbridgeClient.Common.Interfaces
{
    using System.Threading.Tasks;
    using RosbridgeNet.RosbridgeClient.Common.Delegates;

    public interface IRosSubscriber : IRosTopicOperator
    {
        event RosMessageReceivedHandler RosMessageReceived;

        Task SubscribeAsync();

        Task UnsubscribeAsync();
    }
}
