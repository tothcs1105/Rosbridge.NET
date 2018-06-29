namespace RosbridgeNet.RosbridgeClient.Common.Interfaces
{
    using System;
    using System.Threading.Tasks;

    public interface ISocket : IDisposable
    {
        Uri URI { get; }

        bool IsConnected { get; }

        Task ConnectAsync();

        Task DisconnectAsync();

        Task SendAsync(byte[] buffer);

        Task<byte[]> ReceiveAsync();
    }
}
