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

            if (topic == null)
            {
                throw new ArgumentNullException(nameof(topic));
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
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }


            if (string.IsNullOrWhiteSpace(type))
            {
                throw new ArgumentException($"{nameof(type)} cannot be empty!");
            }

            this.Type = type;
        }

        public string Topic { get; protected set; }

        public string Type { get; protected set; }
    }
}
