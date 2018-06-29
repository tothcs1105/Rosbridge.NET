namespace RosbridgeNet.RosbridgeClient.Common.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class RosMessageTypeAttribute : Attribute
    {
        public string RosMessageType { get; private set; }

        public RosMessageTypeAttribute(string rosMessageType)
        {
            if (rosMessageType == null)
            {
                throw new ArgumentNullException(nameof(rosMessageType));
            }

            if (string.IsNullOrWhiteSpace(rosMessageType))
            {
                throw new ArgumentException($"{nameof(rosMessageType)} cannot be empty!");
            }

            this.RosMessageType = rosMessageType;
        }
    }
}
