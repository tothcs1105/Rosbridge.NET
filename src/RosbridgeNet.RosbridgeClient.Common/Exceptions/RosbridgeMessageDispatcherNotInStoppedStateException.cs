namespace RosbridgeNet.RosbridgeClient.Common.Exceptions
{
    using System;

    public class RosbridgeMessageDispatcherNotInStoppedStateException : Exception
    {
        public RosbridgeMessageDispatcherNotInStoppedStateException()
        {
        }

        public RosbridgeMessageDispatcherNotInStoppedStateException(string message) : base(message)
        {
        }

        public RosbridgeMessageDispatcherNotInStoppedStateException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
