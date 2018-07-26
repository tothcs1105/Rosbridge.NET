namespace RosbridgeNet.RosbridgeClient.ProtocolV2
{
    using RosbridgeNet.RosbridgeClient.Common;
    using RosbridgeNet.RosbridgeClient.Common.Interfaces;
    using RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.RosOperations;

    public sealed class RosPublisher : RosPublisherBase, RosbridgeClient.ProtocolV2.Interfaces.IRosPublisher
    {
        public RosPublisher(IRosbridgeMessageDispatcher rosbridgeMessageDispatcher, string topic) : base(rosbridgeMessageDispatcher, topic)
        {
        }

        public RosPublisher(IRosbridgeMessageDispatcher rosbridgeMessageDispatcher, string topic, string type) : base(rosbridgeMessageDispatcher, topic, type)
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
            return new RosUnadvertiseMessage()
            {
                Topic = this.Topic
            };
        }

        protected override object CreatePublishMessage(object message)
        {
            return new RosPublishMessage()
            {
                Id = this.PublishMessageId,
                Topic = this.Topic,
                Message = message
            };
        }
    }
}
