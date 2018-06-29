namespace RosbridgeNet.RosbridgeClient.Common.Abstracts
{
    using System;
    using System.Reflection;
    using RosbridgeNet.RosbridgeClient.Common.Attributes;
    using RosbridgeNet.RosbridgeClient.Common.Exceptions;
    using RosbridgeNet.RosbridgeClient.Common.Interfaces;

    public abstract class RosTopicUser<TRosMessage> : IRosTopicUser<TRosMessage> where TRosMessage : class, new()
    {
        protected readonly IRosbridgeMessageDispatcher rosbridgeMessageDispatcher;

        public RosTopicUser(IRosbridgeMessageDispatcher rosbridgeMessageDispatcher, string topic)
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
            this.Type = GetRosMessageType(typeof(TRosMessage));
        }

        public string Topic { get; private set; }

        public string Type { get; private set; }

        private string GetRosMessageType(Type type)
        {
            RosMessageTypeAttribute rosMessageTypeAttribute = type.GetTypeInfo().GetCustomAttribute<RosMessageTypeAttribute>();

            if (rosMessageTypeAttribute == null)
            {
                throw new RosMessageTypeAttributeMissingException();
            }

            string rosMessageType = rosMessageTypeAttribute.RosMessageType;

            if (rosMessageType == null)
            {
                throw new RosMessageTypeNullException();
            }

            if (string.IsNullOrWhiteSpace(rosMessageType))
            {
                throw new RosMessageTypeEmptyException();
            }

            return rosMessageType;
        }
    }
}
