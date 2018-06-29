namespace RosbridgeNet.RosbridgeClient.ProtocolV2
{
    using RosbridgeNet.RosbridgeClient.Common.Abstracts;
    using RosbridgeNet.RosbridgeClient.Common.Interfaces;
    using RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.RosOperations;

    public class RosPublisher<TRosMessage> : RosPublisherBase<TRosMessage> where TRosMessage : class, new()
    {
        public RosPublisher(IRosbridgeMessageDispatcher messageDispatcher, string topic) : base(messageDispatcher, topic)
        {
            this.RosAdvertiseMessage = new RosAdvertiseMessage();
            this.RosUnadvertiseMessage = new RosUnadvertiseMessage();
            this.RosPublishMessage = new RosPublishMessage<TRosMessage>();
        }

        public RosAdvertiseMessage RosAdvertiseMessage { get; private set; }
        public RosUnadvertiseMessage RosUnadvertiseMessage { get; private set; }
        public RosPublishMessage<TRosMessage> RosPublishMessage { get; private set; }

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

        protected override object CreatePublishMessage(TRosMessage message)
        {
            this.RosPublishMessage.Topic = this.Topic;
            this.RosPublishMessage.Message = message;

            return this.RosPublishMessage;
        }
    }
}
