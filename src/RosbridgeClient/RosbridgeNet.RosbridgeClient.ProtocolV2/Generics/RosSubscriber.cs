namespace RosbridgeNet.RosbridgeClient.ProtocolV2.Generics
{
    using RosbridgeNet.RosbridgeClient.Common.EventArgs;
    using RosbridgeNet.RosbridgeClient.Common.Generics;
    using RosbridgeNet.RosbridgeClient.Common.Generics.EventArgs;
    using RosbridgeNet.RosbridgeClient.Common.Interfaces;
    using RosbridgeNet.RosbridgeClient.ProtocolV2.Generics.Interfaces;
    using RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.RosOperations;
    using RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.RosOperations.Generics;


    public sealed class RosSubscriber<TRosMessage> : RosSubscriberBase<TRosMessage>, IRosSubscriber<TRosMessage> where TRosMessage : class, new()
    {
        public RosSubscriber(IRosbridgeMessageDispatcher rosbridgeMessageDispatcher, string topic, string type) : base(
            rosbridgeMessageDispatcher, topic, type)
        {
            this.RosSubscribeMessage = new RosSubscribeMessage();
            this.RosUnsubscribeMessage = new RosUnsubscribeMessage();
        }

        public RosSubscriber(IRosbridgeMessageDispatcher rosbridgeMessageDispatcher, string topic) : base(rosbridgeMessageDispatcher, topic)
        {
            this.RosSubscribeMessage = new RosSubscribeMessage();
            this.RosUnsubscribeMessage = new RosUnsubscribeMessage();
        }

        public RosSubscribeMessage RosSubscribeMessage { get; private set; }

        public RosUnsubscribeMessage RosUnsubscribeMessage { get; private set; }

        protected override object CreateSubscribeMessage()
        {
            this.RosSubscribeMessage.Topic = this.Topic;
            this.RosSubscribeMessage.Type = this.Type;

            return this.RosSubscribeMessage;
        }

        protected override object CreateUnsubscribeMessage()
        {
            this.RosUnsubscribeMessage.Topic = this.Topic;

            return this.RosUnsubscribeMessage;
        }

        protected override void RosbridgeMessageReceived(object sender, RosbridgeMessageReceivedEventArgs args)
        {
            if (args != null)
            {
                if (args.RosbridgeMessage != null)
                {
                    RosPublishMessage<TRosMessage> receivedPublishMessage =
                        args.RosbridgeMessage.ToObject<RosPublishMessage<TRosMessage>>();

                    if (receivedPublishMessage != null &&
                        !string.IsNullOrEmpty(receivedPublishMessage.Topic) &&
                        receivedPublishMessage.Topic.Equals(this.Topic))
                    {
                        RaiseRosMessageReceived(new RosMessageReceivedEventArgs<TRosMessage>(receivedPublishMessage.Message));
                    }
                }
            }
        }
    }
}
