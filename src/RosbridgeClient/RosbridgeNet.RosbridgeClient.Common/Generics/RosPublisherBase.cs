namespace RosbridgeNet.RosbridgeClient.Common.Generics
{
    using System;
    using System.Threading.Tasks;
    using RosbridgeNet.RosbridgeClient.Common.Generics.Interfaces;
    using RosbridgeNet.RosbridgeClient.Common.Interfaces;

    public abstract class RosPublisherBase<TRosMessage> : RosTopicOperatorBase<TRosMessage>, IRosPublisher<TRosMessage> where TRosMessage : class, new()
    {
        public RosPublisherBase(IRosbridgeMessageDispatcher rosbridgeMessageDispatcher, string topic, string type) : base(rosbridgeMessageDispatcher, topic, type)
        {
        }

        public RosPublisherBase(IRosbridgeMessageDispatcher rosbridgeMessageDispatcher, string topic) : base(rosbridgeMessageDispatcher, topic)
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

        public Task PublishAsync(TRosMessage rosMessage)
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

        protected abstract object CreatePublishMessage(TRosMessage message);
    }
}
