namespace RosbridgeNet.RosbridgeClient.Common.Interfaces
{
    using System.Threading.Tasks;
    using RosbridgeNet.RosbridgeClient.Common.Delegates;

    public interface IRosSubscriber<TRosMessage> : IRosTopicUser<TRosMessage> where TRosMessage : class, new()
    {
        event RosMessageReceivedHandler<TRosMessage> RosMessageReceived;

        Task SubscribeAsync();

        Task UnsubscribeAsync();
    }
}
