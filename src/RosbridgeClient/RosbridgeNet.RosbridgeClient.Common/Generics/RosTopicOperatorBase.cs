namespace RosbridgeNet.RosbridgeClient.Common.Generics
{
    using System;
    using System.Reflection;
    using RosbridgeNet.RosbridgeClient.Common.Attributes;
    using RosbridgeNet.RosbridgeClient.Common.Exceptions;
    using RosbridgeNet.RosbridgeClient.Common.Generics.Interfaces;
    using RosbridgeNet.RosbridgeClient.Common.Interfaces;

    public abstract class RosTopicOperatorBase<TRosMessage> : RosTopicOperatorBase, IRosTopicOperator<TRosMessage> where TRosMessage : class, new()
    {
        protected RosTopicOperatorBase(IRosbridgeMessageDispatcher rosbridgeMessageDispatcher, string topic) : base(rosbridgeMessageDispatcher, topic)
        {
            this.Type = GetRosMessageType(typeof(TRosMessage));
        }

        protected RosTopicOperatorBase(IRosbridgeMessageDispatcher rosbridgeMessageDispatcher, string topic, string type) : base(rosbridgeMessageDispatcher, topic, type)
        {
        }

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
