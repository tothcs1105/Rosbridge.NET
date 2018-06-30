namespace RosbridgeNet.RosbridgeClient.ProtocolV2.Exceptions
{
    using System;

    public class SocketException : Exception
    {
        public SocketException()
        {
        }

        public SocketException(string message) : base(message)
        {
        }

        public SocketException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
