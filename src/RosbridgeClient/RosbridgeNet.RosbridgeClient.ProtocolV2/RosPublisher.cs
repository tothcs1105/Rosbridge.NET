namespace RosbridgeNet.RosbridgeClient.ProtocolV2
{
    using RosbridgeNet.RosbridgeClient.Common;
    using RosbridgeNet.RosbridgeClient.Common.Interfaces;
    using RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.RosOperations;

    public class RosPublisher : RosPublisherBase<AdvertiseMessage, UnadvertiseMessage, PublishMessage>, RosbridgeClient.ProtocolV2.Interfaces.IRosPublisher
    {
        protected RosPublisher(IRosbridgeMessageDispatcher rosbridgeMessageDispatcher, string topic) : base(rosbridgeMessageDispatcher, topic)
        {
        }

        public RosPublisher(IRosbridgeMessageDispatcher rosbridgeMessageDispatcher, string topic, string type) : base(rosbridgeMessageDispatcher, topic, type)
        {
        }

        public string MessageId { get; set; }

        protected override AdvertiseMessage CreateAdvertiseMessage()
        {
            return new AdvertiseMessage()
            {
                Topic = this.Topic,
                Type = this.Type
            };
        }

        protected override UnadvertiseMessage CreateUnadvertiseMessage()
        {
            return new UnadvertiseMessage()
            {
                Topic = this.Topic
            };
        }

        protected override PublishMessage CreatePublishMessage(object message)
        {
            return new PublishMessage()
            {
                Id = this.MessageId,
                Topic = this.Topic,
                Message = message
            };
        }
    }
}
