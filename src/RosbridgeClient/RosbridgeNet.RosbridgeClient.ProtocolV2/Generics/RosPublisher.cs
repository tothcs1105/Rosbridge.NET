namespace RosbridgeNet.RosbridgeClient.ProtocolV2.Generics
{
    using RosbridgeNet.RosbridgeClient.Common.Generics;
    using RosbridgeNet.RosbridgeClient.Common.Interfaces;
    using RosbridgeNet.RosbridgeClient.ProtocolV2.Generics.Interfaces;
    using RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.RosOperations;
    using RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.RosOperations.Generics;

    public sealed class RosPublisher<TRosMessage> : RosPublisherBase<TRosMessage>, IRosPublisher<TRosMessage> where TRosMessage : class, new()
    {
        public RosPublisher(IRosbridgeMessageDispatcher rosbridgeMessageDispatcher, string topic, string type) : base(rosbridgeMessageDispatcher, topic, type)
        {
        }

        public RosPublisher(IRosbridgeMessageDispatcher messageDispatcher, string topic) : base(messageDispatcher, topic)
        {
        }

        public string PublishMessageId { get; set; }

        protected override object CreateAdvertiseMessage()
        {
            return new RosAdvertiseMessage()
            {
                Topic = this.Topic,
                Type = this.Type
            };
        }

        protected override object CreateUnadvertiseMessage()
        {
            return new RosUnsubscribeMessage()
            {
                Topic = this.Topic
            };
        }

        protected override object CreatePublishMessage(TRosMessage message)
        {
            return new RosPublishMessage<TRosMessage>()
            {
                Id = this.PublishMessageId,
                Topic = this.Topic,
                Message = message
            };
        }
    }
}