namespace RosbridgeNet.RosbridgeClient.Common.Generics.Interfaces
{
    using System.Threading.Tasks;
    using RosbridgeNet.RosbridgeClient.Common.Generics.Delegates;

    public interface IRosSubscriber<TRosMessage> : IRosTopicOperator<TRosMessage> where TRosMessage : class, new()
    {
        event RosMessageReceivedHandler<TRosMessage> RosMessageReceived;

        Task SubscribeAsync();

        Task UnsubscribeAsync();
    }
}
