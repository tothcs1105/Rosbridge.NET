namespace RosbridgeNet.RosbridgeClient.ProtocolV2.Generics
{
    using RosbridgeNet.RosbridgeClient.Common.EventArgs;
    using RosbridgeNet.RosbridgeClient.Common.Generics;
    using RosbridgeNet.RosbridgeClient.Common.Generics.EventArgs;
    using RosbridgeNet.RosbridgeClient.Common.Interfaces;
    using RosbridgeNet.RosbridgeClient.ProtocolV2.Generics.Interfaces;
    using RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.Enums;
    using RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.RosOperations;
    using RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.RosOperations.Generics;


    public sealed class RosSubscriber<TRosMessage> : RosSubscriberBase<TRosMessage>, IRosSubscriber<TRosMessage> where TRosMessage : class, new()
    {
        public RosSubscriber(IRosbridgeMessageDispatcher rosbridgeMessageDispatcher, string topic, string type) : base(rosbridgeMessageDispatcher, topic, type)
        {
        }

        public RosSubscriber(IRosbridgeMessageDispatcher rosbridgeMessageDispatcher, string topic) : base(rosbridgeMessageDispatcher, topic)
        {
        }

        public MessageCompressionLevel? MessageCompressionLevel { get; set; }

        public int? FragmentSize { get; set; }

        public string MessageId { get; set; }

        public int? ThrottleRate { get; set; }

        public int? QueueLength { get; set; }

        protected override object CreateSubscribeMessage()
        {
            return new RosSubscribeMessage()
            {
                Compression = this.MessageCompressionLevel,
                FragmentSize = this.FragmentSize,
                Id = this.MessageId,
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
                Id = this.MessageId,
                Topic = this.Topic
            };
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
