namespace RosbridgeNet.RosbridgeClient.Common.Extensions
{
    using System;
    using System.Reflection;
    using RosbridgeNet.RosbridgeClient.Common.Attributes;
    using RosbridgeNet.RosbridgeClient.Common.Exceptions;

    public static class TypeExtensions
    {
        public static string GetRosMessageType(this Type type)
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
