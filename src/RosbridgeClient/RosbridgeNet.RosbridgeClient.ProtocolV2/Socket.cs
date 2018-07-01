namespace RosbridgeNet.RosbridgeClient.ProtocolV2
{
    using System;
    using System.IO;
    using System.Net.WebSockets;
    using System.Threading;
    using System.Threading.Tasks;
    using RosbridgeNet.RosbridgeClient.Common.Interfaces;
    using RosbridgeNet.RosbridgeClient.ProtocolV2.Exceptions;
    using RosbridgeNet.RosbridgeClient.ProtocolV2.Interfaces;

    public sealed class Socket : ISocket
    {
        private readonly IClientWebSocket clientWebSocket;
        private readonly CancellationTokenSource cancellationTokenSource;
        private bool disposed;

        public Socket(IClientWebSocket clientWebSocket, Uri uri, CancellationTokenSource cancellationTokenSource)
        {
            if (clientWebSocket == null)
            {
                throw new ArgumentNullException(nameof(clientWebSocket));
            }

            if (uri == null)
            {
                throw new ArgumentNullException(nameof(uri));
            }

            if (cancellationTokenSource == null)
            {
                throw new ArgumentNullException(nameof(cancellationTokenSource));
            }

            this.clientWebSocket = clientWebSocket;
            this.URI = uri;
            this.cancellationTokenSource = cancellationTokenSource;
        }

        public Uri URI { get; private set; }

        public bool IsConnected
        {
            get { return clientWebSocket.State == WebSocketState.Connecting; }
        }

        public Task ConnectAsync()
        {
            if (disposed)
            {
                throw new ObjectDisposedException(nameof(Socket));
            }

            return Task.Run(async () =>
            {
                await this.clientWebSocket.ConnectAsync(URI, cancellationTokenSource.Token);

                if (this.clientWebSocket.State != WebSocketState.Open)
                {
                    throw new SocketException(
                        $"Could not connect to {URI.AbsolutePath}, socket state: {this.clientWebSocket.State.ToString()}");
                }
            });
        }

        public Task DisconnectAsync()
        {
            if (disposed)
            {
                throw new ObjectDisposedException(nameof(Socket));
            }

            return Task.Run(async () =>
            {
                await this.clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Close",
                    this.cancellationTokenSource.Token);

                if (this.clientWebSocket.State != WebSocketState.Closed)
                {
                    throw new SocketException(
                        $"Could not connect to {URI.AbsolutePath} socket state: {this.clientWebSocket.State.ToString()}");
                }
            });
        }

        public Task SendAsync(byte[] buffer)
        {
            if (disposed)
            {
                throw new ObjectDisposedException(nameof(Socket));
            }

            if (null == buffer)
            {
                throw new ArgumentNullException(nameof(buffer));
            }

            return this.clientWebSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true,
                this.cancellationTokenSource.Token);
        }

        public Task<byte[]> ReceiveAsync()
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException(nameof(Socket));
            }

            TaskCompletionSource<byte[]> taskCompletion = new TaskCompletionSource<byte[]>();

            Task.Run(async () =>
            {
                using (MemoryStream buffer = new MemoryStream())
                {
                    WebSocketReceiveResult result;

                    do
                    {
                        byte[] tmpBuffer = new byte[65535];

                        result = await this.clientWebSocket.ReceiveAsync(new ArraySegment<byte>(tmpBuffer), this.cancellationTokenSource.Token);

                        if (null != result)
                        {
                            if (result.MessageType == WebSocketMessageType.Close)
                            {
                                await this.clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "OK", this.cancellationTokenSource.Token);
                                taskCompletion.SetException(new SocketException("Connection closed by the server!"));
                            }

                            if (result.MessageType == WebSocketMessageType.Binary)
                            {
                                await this.clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "OK", this.cancellationTokenSource.Token);
                                taskCompletion.SetException(new SocketException("Server sent binary data!"));
                            }

                            buffer.Write(tmpBuffer, 0, result.Count);
                        }
                    } while (null != result && !result.EndOfMessage);

                    taskCompletion.SetResult(buffer.ToArray());
                }
            });

            return taskCompletion.Task;
        }
        public void Dispose()
        {
            this.disposed = true;

            try
            {
                if (this.clientWebSocket != null)
                {
                    this.clientWebSocket.Abort();
                    this.clientWebSocket.Dispose();
                }
            }
            catch { }
        }
    }
}
