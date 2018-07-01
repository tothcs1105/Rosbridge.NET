namespace RosbridgeNet.RosbridgeClient.Common.Exceptions
{
    using System;

    public class RosMessageTypeEmptyException : Exception
    {
        public RosMessageTypeEmptyException()
        {
        }

        public RosMessageTypeEmptyException(string message) : base(message)
        {
        }

        public RosMessageTypeEmptyException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
