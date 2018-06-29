namespace RosbridgeNet.RosbridgeClient.ProtocolV2
{
    using System;
    using System.Threading.Tasks;
    using RosbridgeNet.RosbridgeClient.Common.Interfaces;

    public class Socket : ISocket
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Uri URI { get; }

        public bool IsConnected { get; }

        public Task ConnectAsync()
        {
            throw new NotImplementedException();
        }

        public Task DisconnectAsync()
        {
            throw new NotImplementedException();
        }

        public Task SendAsync(byte[] buffer)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> ReceiveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
