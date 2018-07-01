namespace RosbridgeNet.RosbridgeClient.ProtocolV2.Wrappers
{
    using System;
    using System.Net.WebSockets;
    using System.Threading;
    using System.Threading.Tasks;
    using RosbridgeNet.RosbridgeClient.ProtocolV2.Interfaces;

    public class ClientWebSocketWrapper : IClientWebSocket
    {
        private readonly ClientWebSocket clientWebSocket;

        public ClientWebSocketWrapper(ClientWebSocket clientWebSocket)
        {
            if (clientWebSocket == null)
            {
                throw new ArgumentNullException(nameof(clientWebSocket));
            }

            this.clientWebSocket = clientWebSocket;
        }

        public WebSocketState State
        {
            get
            {
                return this.clientWebSocket.State;
            }
        }

        public Task ConnectAsync(Uri uri, CancellationToken cancellationToken)
        {
            return this.clientWebSocket.ConnectAsync(uri, cancellationToken);
        }

        public Task CloseAsync(WebSocketCloseStatus closeStatus, string statusDescription, CancellationToken cancellationToken)
        {
            return this.clientWebSocket.CloseAsync(closeStatus, statusDescription, cancellationToken);
        }

        public Task<WebSocketReceiveResult> ReceiveAsync(ArraySegment<byte> buffer, CancellationToken cancellationToken)
        {
            return this.clientWebSocket.ReceiveAsync(buffer, cancellationToken);
        }

        public Task SendAsync(ArraySegment<byte> buffer, WebSocketMessageType messageType, bool endOfMessage,
            CancellationToken cancellationToken)
        {
            return this.clientWebSocket.SendAsync(buffer, messageType, endOfMessage, cancellationToken);
        }

        public void Abort()
        {
            this.clientWebSocket.Abort();
        }

        public void Dispose()
        {
            this.clientWebSocket.Dispose();
        }
    }
}
