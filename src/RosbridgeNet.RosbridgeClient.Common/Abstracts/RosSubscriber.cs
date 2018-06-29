namespace RosbridgeNet.RosbridgeClient.Common.Abstracts
{
    using System.Threading.Tasks;
    using RosbridgeNet.RosbridgeClient.Common.Delegates;
    using RosbridgeNet.RosbridgeClient.Common.EventArgs;
    using RosbridgeNet.RosbridgeClient.Common.Interfaces;

    public abstract class RosSubscriber<TRosMessage> : RosTopicUser<TRosMessage>, IRosSubscriber<TRosMessage> where TRosMessage : class, new()
    {
        public RosSubscriber(IRosbridgeMessageDispatcher rosbridgeMessageDispatcher, string topic) : base(rosbridgeMessageDispatcher, topic)
        {
            this.rosbridgeMessageDispatcher.RosbridgeMessageReceived += RosbridgeMessageReceived;
        }

        public event RosMessageReceivedHandler<TRosMessage> RosMessageReceived;

        public Task SubscribeAsync()
        {
            object subscriberMessage = this.CreateSubscribeMessage();

            return this.rosbridgeMessageDispatcher.SendAsync(subscriberMessage);
        }

        public Task UnsubscribeAsync()
        {
            object unsubscribeMessage = this.CreateUnsubscribeMessage();

            return this.rosbridgeMessageDispatcher.SendAsync(unsubscribeMessage);
        }

        protected abstract object CreateSubscribeMessage();

        protected abstract object CreateUnsubscribeMessage();

        protected abstract void RosbridgeMessageReceived(object sender, RosbridgeMessageReceivedEventArgs args);
    }
}
