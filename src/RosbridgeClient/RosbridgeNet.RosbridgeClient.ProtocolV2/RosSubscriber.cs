namespace RosbridgeNet.RosbridgeClient.ProtocolV2
{
    using RosbridgeNet.RosbridgeClient.Common;
    using RosbridgeNet.RosbridgeClient.Common.EventArgs;
    using RosbridgeNet.RosbridgeClient.Common.Interfaces;
    using RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.Enums;
    using RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.RosOperations;

    public class RosSubscriber : RosSubscriberBase<SubscribeMessage, UnsubscribeMessage>, Interfaces.IRosSubscriber
    {
        public RosSubscriber(IRosbridgeMessageDispatcher rosbridgeMessageDispatcher, string topic) : base(rosbridgeMessageDispatcher, topic)
        {
        }

        public RosSubscriber(IRosbridgeMessageDispatcher rosbridgeMessageDispatcher, string topic, string type) : base(rosbridgeMessageDispatcher, topic, type)
        {
        }

        public MessageCompressionLevel? MessageCompressionLevel { get; set; }

        public int? FragmentSize { get; set; }

        public string MessageId { get; set; }

        public int? ThrottleRate { get; set; }

        public int? QueueLength { get; set; }

        protected override SubscribeMessage CreateSubscribeMessage()
        {
            return new SubscribeMessage()
            {
                Id = this.MessageId,
                Topic = this.Topic,
                Type = this.Type,
                ThrottleRate = this.ThrottleRate,
                FragmentSize = this.FragmentSize,
                QueueLength = this.QueueLength,
                Compression = this.MessageCompressionLevel
            };
        }

        protected override UnsubscribeMessage CreateUnsubscribeMessage()
        {
            return new UnsubscribeMessage()
            {
                Id = this.MessageId,
                Topic = this.Topic
            };
        }

        protected override void RosbridgeMessageReceivedHandler(object sender, RosbridgeMessageReceivedEventArgs args)
        {
            if (args != null)
            {
                if (args.RosbridgeMessage != null)
                {
                    PublishMessage receivedPublishMessage = args.RosbridgeMessage.ToObject<PublishMessage>();

                    if (receivedPublishMessage != null && !string.IsNullOrEmpty(receivedPublishMessage.Topic) && receivedPublishMessage.Topic.Equals(this.Topic))
                    {
                        RaiseRosMessageReceived(new RosMessageReceivedEventArgs(receivedPublishMessage.Message));
                    }
                }
            }
        }
    }
}
