namespace RosbridgeNet.RosbridgeClient.Common
{
    using System;
    using System.Threading.Tasks;
    using RosbridgeNet.RosbridgeClient.Common.Interfaces;

    public abstract class RosPublisherBase<TAdvertise, TUnadvertise, TPublish> : RosTopicOperatorBase, IRosPublisher where TAdvertise : class, new() where TUnadvertise : class, new() where TPublish : class, new()
    {
        public RosPublisherBase(IRosbridgeMessageDispatcher rosbridgeMessageDispatcher, string topic) : base(rosbridgeMessageDispatcher, topic)
        {
        }

        public RosPublisherBase(IRosbridgeMessageDispatcher rosbridgeMessageDispatcher, string topic, string type) : base(rosbridgeMessageDispatcher, topic, type)
        {
        }

        public Task AdvertiseAsync()
        {
            TAdvertise advertiseMessage = this.CreateAdvertiseMessage();

            return this.rosbridgeMessageDispatcher.SendAsync(advertiseMessage);
        }

        public Task UnadvertiseAsync()
        {
            TUnadvertise unadvertiseMessage = this.CreateUnadvertiseMessage();

            return this.rosbridgeMessageDispatcher.SendAsync(unadvertiseMessage);
        }

        public Task PublishAsync(object rosMessage)
        {
            if (rosMessage == null)
            {
                throw new ArgumentNullException(nameof(rosMessage));
            }

            TPublish publishMessage = this.CreatePublishMessage(rosMessage);

            return this.rosbridgeMessageDispatcher.SendAsync(publishMessage);
        }

        protected abstract TAdvertise CreateAdvertiseMessage();

        protected abstract TUnadvertise CreateUnadvertiseMessage();

        protected abstract TPublish CreatePublishMessage(object message);
    }
}
