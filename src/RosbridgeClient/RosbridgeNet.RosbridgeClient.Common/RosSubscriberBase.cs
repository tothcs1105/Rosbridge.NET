namespace RosbridgeNet.RosbridgeClient.Common
{
    using System.Threading.Tasks;
    using RosbridgeNet.RosbridgeClient.Common.Delegates;
    using RosbridgeNet.RosbridgeClient.Common.EventArgs;
    using RosbridgeNet.RosbridgeClient.Common.Interfaces;

    public abstract class RosSubscriberBase : RosTopicOperatorBase, IRosSubscriber
    {
        protected RosSubscriberBase(IRosbridgeMessageDispatcher rosbridgeMessageDispatcher, string topic) : base(rosbridgeMessageDispatcher, topic)
        {
            this.rosbridgeMessageDispatcher.RosbridgeMessageReceived += this.RosbridgemessageReceivedHandler;
        }

        protected RosSubscriberBase(IRosbridgeMessageDispatcher rosbridgeMessageDispatcher, string topic, string type) : base(rosbridgeMessageDispatcher, topic, type)
        {
            this.rosbridgeMessageDispatcher.RosbridgeMessageReceived += this.RosbridgemessageReceivedHandler;
        }

        public event RosMessageReceivedHandler RosMessageReceived;

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

        protected void RaiseRosMessageReceived(RosMessageReceivedEventArgs args)
        {
            RosMessageReceived?.Invoke(this, args);
        }

        protected abstract object CreateSubscribeMessage();

        protected abstract object CreateUnsubscribeMessage();

        protected abstract void RosbridgemessageReceivedHandler(object sender, RosbridgeMessageReceivedEventArgs args);
    }
}
