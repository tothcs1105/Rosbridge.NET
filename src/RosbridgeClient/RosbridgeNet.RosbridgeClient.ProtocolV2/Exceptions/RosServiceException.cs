namespace RosbridgeNet.RosbridgeClient.ProtocolV2.Exceptions
{
    using System;

    public class RosServiceException : Exception
    {
        public RosServiceException()
        {
        }

        public RosServiceException(string message) : base(message)
        {
        }

        public RosServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
