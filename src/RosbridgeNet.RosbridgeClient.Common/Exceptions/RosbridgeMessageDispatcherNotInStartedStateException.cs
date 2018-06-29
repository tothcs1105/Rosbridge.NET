namespace RosbridgeNet.RosbridgeClient.Common.Exceptions
{
    using System;

    public class RosbridgeMessageDispatcherNotInStartedStateException : Exception
    {
        public RosbridgeMessageDispatcherNotInStartedStateException()
        {
        }

        public RosbridgeMessageDispatcherNotInStartedStateException(string message) : base(message)
        {
        }

        public RosbridgeMessageDispatcherNotInStartedStateException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
