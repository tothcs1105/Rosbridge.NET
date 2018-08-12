namespace RosbridgeNet.RosbridgeClient.Common
{
    using System.Threading.Tasks;
    using Newtonsoft.Json.Linq;
    using RosbridgeNet.RosbridgeClient.Common.Delegates;
    using RosbridgeNet.RosbridgeClient.Common.EventArgs;
    using RosbridgeNet.RosbridgeClient.Common.Interfaces;

    public abstract class RosSubscriberBase<TSubscribe, TUnsubscribe> : RosTopicOperatorBase, IRosSubscriber where TSubscribe : class, new() where TUnsubscribe : class, new()
    {
        protected RosSubscriberBase(IRosbridgeMessageDispatcher rosbridgeMessageDispatcher, string topic) : base(rosbridgeMessageDispatcher, topic)
        {
            this.rosbridgeMessageDispatcher.RosbridgeMessageReceived += this.RosbridgeMessageReceivedHandler;
        }

        protected RosSubscriberBase(IRosbridgeMessageDispatcher rosbridgeMessageDispatcher, string topic, string type) : base(rosbridgeMessageDispatcher, topic, type)
        {
            this.rosbridgeMessageDispatcher.RosbridgeMessageReceived += this.RosbridgeMessageReceivedHandler;
        }

        public event RosMessageReceivedHandler RosMessageReceived;

        public Task SubscribeAsync()
        {
            TSubscribe subscriberMessage = this.CreateSubscribeMessage();

            return this.rosbridgeMessageDispatcher.SendAsync(subscriberMessage);
        }

        public Task UnsubscribeAsync()
        {
            TUnsubscribe unsubscribeMessage = this.CreateUnsubscribeMessage();

            return this.rosbridgeMessageDispatcher.SendAsync(unsubscribeMessage);
        }

        protected abstract TSubscribe CreateSubscribeMessage();

        protected abstract TUnsubscribe CreateUnsubscribeMessage();

        protected abstract RosMessageReceivedEventArgs HandleRosbridgeMessage(JObject rosbridgeMessage);

        private void RosbridgeMessageReceivedHandler(object sender, RosbridgeMessageReceivedEventArgs args)
        {
            if (args != null)
            {
                RosMessageReceivedEventArgs rosMessageReceivedEventArgs = this.HandleRosbridgeMessage(args.RosbridgeMessage);

                if (rosMessageReceivedEventArgs != null)
                {
                    RosMessageReceived?.Invoke(this, rosMessageReceivedEventArgs);
                }
            }
        }
    }
}
