namespace RosbridgeNet.RosbridgeClient.Common.Exceptions
{
    using System;

    public class RosMessageTypeNullException : Exception
    {
        public RosMessageTypeNullException()
        {
        }

        public RosMessageTypeNullException(string message) : base(message)
        {
        }

        public RosMessageTypeNullException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
