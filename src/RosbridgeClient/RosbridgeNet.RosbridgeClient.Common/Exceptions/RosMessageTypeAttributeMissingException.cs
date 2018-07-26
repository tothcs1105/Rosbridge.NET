namespace RosbridgeNet.RosbridgeClient.Common.Exceptions
{
    using System;

    public class RosMessageTypeAttributeMissingException : Exception
    {
        public RosMessageTypeAttributeMissingException()
        {
        }

        public RosMessageTypeAttributeMissingException(string message) : base(message)
        {
        }

        public RosMessageTypeAttributeMissingException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
