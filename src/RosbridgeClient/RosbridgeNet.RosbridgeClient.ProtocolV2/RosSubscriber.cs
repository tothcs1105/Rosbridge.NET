namespace RosbridgeNet.RosbridgeClient.ProtocolV2
{
    using RosbridgeNet.RosbridgeClient.Common;
    using RosbridgeNet.RosbridgeClient.Common.EventArgs;
    using RosbridgeNet.RosbridgeClient.Common.Interfaces;
    using RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.Enums;
    using RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.RosOperations;

    public sealed class RosSubscriber : RosSubscriberBase, Interfaces.IRosSubscriber
    {
        public RosSubscriber(IRosbridgeMessageDispatcher rosbridgeMessageDispatcher, string topic) : base(rosbridgeMessageDispatcher, topic)
        {
        }

        public RosSubscriber(IRosbridgeMessageDispatcher rosbridgeMessageDispatcher, string topic, string type) : base(rosbridgeMessageDispatcher, topic, type)
        {
        }

        public MessageCompressionLevel? MessageCompressionLevel { get; set; }

        public int? FragmentSize { get; set; }

        public string Id { get; set; }

        public int? ThrottleRate { get; set; }

        public int? QueueLength { get; set; }

        protected override object CreateSubscribeMessage()
        {
            return new RosSubscribeMessage()
            {
                Compression = this.MessageCompressionLevel,
                FragmentSize = this.FragmentSize,
                Id = this.Id,
                Topic = this.Topic,
                ThrottleRate = this.ThrottleRate,
                Type = this.Type,
                QueueLength = this.QueueLength,
            };
        }

        protected override object CreateUnsubscribeMessage()
        {
            return new RosUnsubscribeMessage()
            {
                Id = this.Id,
                Topic = this.Topic
            };
        }

        protected override void RosbridgemessageReceivedHandler(object sender, RosbridgeMessageReceivedEventArgs args)
        {
            if (args != null)
            {
                if (args.RosbridgeMessage != null)
                {
                    RosPublishMessage receivedPublishMessage = args.RosbridgeMessage.ToObject<RosPublishMessage>();

                    if (receivedPublishMessage != null &&
                        !string.IsNullOrEmpty(receivedPublishMessage.Topic) &&
                        receivedPublishMessage.Topic.Equals(this.Topic))
                    {
                        RaiseRosMessageReceived(new RosMessageReceivedEventArgs(receivedPublishMessage.Message));
                    }
                }
            }
        }
    }
}
