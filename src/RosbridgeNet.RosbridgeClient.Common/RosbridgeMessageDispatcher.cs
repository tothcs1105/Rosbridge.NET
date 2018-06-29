namespace RosbridgeNet.RosbridgeClient.Common
{
    using System;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Linq;
    using RosbridgeNet.RosbridgeClient.Common.Delegates;
    using RosbridgeNet.RosbridgeClient.Common.Enums;
    using RosbridgeNet.RosbridgeClient.Common.EventArgs;
    using RosbridgeNet.RosbridgeClient.Common.Exceptions;
    using RosbridgeNet.RosbridgeClient.Common.Interfaces;

    public sealed class RosbridgeMessageDispatcher : IRosbridgeMessageDispatcher
    {
        private ISocket socket;
        private IRosbridgeMessageSerializer rosbridgeMessageSerializer;
        private bool disposed;
        private Task receivingTask;

        public RosbridgeMessageDispatcher(ISocket socket, IRosbridgeMessageSerializer rosbridgeMessageSerializer)
        {
            if (socket == null)
            {
                throw new ArgumentNullException(nameof(socket));
            }

            if (rosbridgeMessageSerializer == null)
            {
                throw new ArgumentNullException(nameof(rosbridgeMessageSerializer));
            }

            this.socket = socket;
            this.rosbridgeMessageSerializer = rosbridgeMessageSerializer;
        }

        public event RosbridgeMessageReceivedHanlder RosbridgeMessageReceived;

        public RosbridgeMessageDispatcherStates CurrentState
        {
            get;
            private set;
        }

        public Task StartAsync()
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException(nameof(RosbridgeMessageDispatcher));
            }

            if (this.CurrentState != RosbridgeMessageDispatcherStates.Stopped)
            {
                throw new RosbridgeMessageDispatcherNotInStoppedStateException();
            }

            Task startingTask = Task.Run(async () =>
            {
                this.CurrentState = RosbridgeMessageDispatcherStates.Starting;

                try
                {

                    await this.socket.ConnectAsync();
                }
                catch
                {
                    this.CurrentState = RosbridgeMessageDispatcherStates.Stopped;
                    throw;
                }

                this.CurrentState = RosbridgeMessageDispatcherStates.Started;
            });

            this.receivingTask = startingTask.ContinueWith(async (socketStartingTask) =>
               {
                   while (this.socket.IsConnected && this.CurrentState == RosbridgeMessageDispatcherStates.Started)
                   {
                       byte[] serializedMessage = await this.socket.ReceiveAsync();

                       JObject jsonMessage = this.rosbridgeMessageSerializer.Deserialize(serializedMessage);

                       this.RosbridgeMessageReceived?.Invoke(this, new RosbridgeMessageReceivedEventArgs(jsonMessage));
                   }
               });

            return startingTask;
        }

        public Task StopAsync()
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException(nameof(RosbridgeMessageDispatcher));
            }

            if (this.CurrentState != RosbridgeMessageDispatcherStates.Started)
            {
                throw new RosbridgeMessageDispatcherNotInStartedStateException();
            }

            this.CurrentState = RosbridgeMessageDispatcherStates.Stopping;

            return Task.Run(async () =>
            {
                if (this.socket != null)
                {
                    await this.socket.DisconnectAsync();
                }

                if (this.receivingTask != null)
                {
                    await this.receivingTask;
                    this.receivingTask = null;
                }

                this.CurrentState = RosbridgeMessageDispatcherStates.Stopped;
            });
        }

        public Task SendAsync<TRosbridgeMessage>(TRosbridgeMessage rosbridgeMessage) where TRosbridgeMessage : class, new()
        {
            if (rosbridgeMessage == null)
            {
                throw new ArgumentNullException(nameof(rosbridgeMessage));
            }

            if (this.disposed)
            {
                throw new ObjectDisposedException(nameof(RosbridgeMessageDispatcher));
            }

            if (this.CurrentState != RosbridgeMessageDispatcherStates.Started)
            {
                throw new RosbridgeMessageDispatcherNotInStartedStateException();
            }

            byte[] serializedMessage = this.rosbridgeMessageSerializer.Serialize(rosbridgeMessage);

            return this.socket.SendAsync(serializedMessage);
        }

        public void Dispose()
        {
            if (this.disposed)
            {
                return;
            }

            this.disposed = true;
            this.CurrentState = RosbridgeMessageDispatcherStates.Stopped;

            Task.Run(async () =>
            {
                if (this.socket != null)
                {
                    await this.socket.DisconnectAsync();
                    this.socket.Dispose();
                    this.socket = null;
                }

                if (this.receivingTask != null)
                {
                    await this.receivingTask;
                    this.receivingTask = null;
                }

                this.rosbridgeMessageSerializer = null;
            });

            GC.SuppressFinalize(this);
        }
    }
}
