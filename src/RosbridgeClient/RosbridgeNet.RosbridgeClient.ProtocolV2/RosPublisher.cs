namespace RosbridgeNet.RosbridgeClient.ProtocolV2
{
    using RosbridgeNet.RosbridgeClient.Common;
    using RosbridgeNet.RosbridgeClient.Common.Interfaces;
    using RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.RosOperations;
    using IRosPublisher = RosbridgeNet.RosbridgeClient.ProtocolV2.Interfaces.IRosPublisher;

    public sealed class RosPublisher : RosPublisherBase, IRosPublisher
    {
        public RosPublisher(IRosbridgeMessageDispatcher rosbridgeMessageDispatcher, string topic) : base(rosbridgeMessageDispatcher, topic)
        {
            this.RosAdvertiseMessage = new RosAdvertiseMessage();
            this.RosUnadvertiseMessage = new RosUnadvertiseMessage();
            this.RosPublishMessage = new RosPublishMessage();
        }

        public RosPublisher(IRosbridgeMessageDispatcher rosbridgeMessageDispatcher, string topic, string type) : base(rosbridgeMessageDispatcher, topic, type)
        {
            this.RosAdvertiseMessage = new RosAdvertiseMessage();
            this.RosUnadvertiseMessage = new RosUnadvertiseMessage();
            this.RosPublishMessage = new RosPublishMessage();
        }

        public RosAdvertiseMessage RosAdvertiseMessage { get; }
        public RosUnadvertiseMessage RosUnadvertiseMessage { get; }
        public RosPublishMessage RosPublishMessage { get; }

        protected override object CreateAdvertiseMessage()
        {
            this.RosAdvertiseMessage.Topic = this.Topic;
            this.RosAdvertiseMessage.Type = this.Type;

            return this.RosAdvertiseMessage;
        }

        protected override object CreateUnadvertiseMessage()
        {
            this.RosUnadvertiseMessage.Topic = this.Topic;

            return this.RosUnadvertiseMessage;
        }

        protected override object CreatePublishMessage(object message)
        {
            this.RosPublishMessage.Topic = this.Topic;
            this.RosPublishMessage.Message = message;

            return this.RosPublishMessage;
        }
    }
}
