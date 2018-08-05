namespace RosbridgeNet.RosbridgeClient.Common
{
    using System;
    using RosbridgeNet.RosbridgeClient.Common.Interfaces;

    public abstract class RosTopicOperatorBase : IRosTopicOperator
    {
        protected readonly IRosbridgeMessageDispatcher rosbridgeMessageDispatcher;

        protected RosTopicOperatorBase(IRosbridgeMessageDispatcher rosbridgeMessageDispatcher, string topic)
        {
            if (rosbridgeMessageDispatcher == null)
            {
                throw new ArgumentNullException(nameof(rosbridgeMessageDispatcher));
            }

            if (string.IsNullOrWhiteSpace(topic))
            {
                throw new ArgumentException($"{nameof(topic)} cannot be empty!");
            }

            this.rosbridgeMessageDispatcher = rosbridgeMessageDispatcher;
            this.Topic = topic;
        }

        protected RosTopicOperatorBase(IRosbridgeMessageDispatcher rosbridgeMessageDispatcher, string topic, string type) : this(rosbridgeMessageDispatcher, topic)
        {
            if (string.IsNullOrWhiteSpace(type))
            {
                throw new ArgumentException($"{nameof(type)} cannot be empty!");
            }

            this.Type = type;
        }

        public string Topic { get; private set; }

        public string Type { get; protected set; }
    }
}
