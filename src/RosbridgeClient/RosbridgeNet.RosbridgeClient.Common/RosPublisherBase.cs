namespace RosbridgeNet.RosbridgeClient.Common
{
    using System;
    using System.Threading.Tasks;
    using RosbridgeNet.RosbridgeClient.Common.Interfaces;

    public abstract class RosPublisherBase : RosTopicOperatorBase, IRosPublisher
    {
        public RosPublisherBase(IRosbridgeMessageDispatcher rosbridgeMessageDispatcher, string topic) : base(rosbridgeMessageDispatcher, topic)
        {
        }

        public RosPublisherBase(IRosbridgeMessageDispatcher rosbridgeMessageDispatcher, string topic, string type) : base(rosbridgeMessageDispatcher, topic, type)
        {
        }

        public Task AdvertiseAsync()
        {
            object advertiseMessage = this.CreateAdvertiseMessage();

            return this.rosbridgeMessageDispatcher.SendAsync(advertiseMessage);
        }

        public Task UnadvertiseAsync()
        {
            object unadvertiseMessage = this.CreateUnadvertiseMessage();

            return this.rosbridgeMessageDispatcher.SendAsync(unadvertiseMessage);
        }

        public Task PublishAsync(object rosMessage)
        {
            if (rosMessage == null)
            {
                throw new ArgumentNullException(nameof(rosMessage));
            }

            object publishMessage = this.CreatePublishMessage(rosMessage);

            return this.rosbridgeMessageDispatcher.SendAsync(publishMessage);
        }

        protected abstract object CreateAdvertiseMessage();

        protected abstract object CreateUnadvertiseMessage();

        protected abstract object CreatePublishMessage(object message);
    }
}
