namespace RosbridgeNet.Client.Console
{
    using System;
    using System.Net.WebSockets;
    using System.Threading;
    using RosbridgeNet.RosbridgeClient.Common;
    using RosbridgeNet.RosbridgeClient.Common.Interfaces;
    using RosbridgeNet.RosbridgeClient.ProtocolV2;
    using RosbridgeNet.RosbridgeClient.ProtocolV2.Interfaces;
    using RosbridgeNet.RosbridgeClient.ProtocolV2.Wrappers;

    class Program
    {
        static void Main(string[] args)
        {
            Publish();
        }

        static void Publish()
        {
            Uri uri = new Uri("ws://localhost:9090");
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            IClientWebSocket clientWebSocket = new ClientWebSocketWrapper(new ClientWebSocket());
            ISocket socket = new Socket(clientWebSocket, uri, cancelTokenSource);
            IRosbridgeMessageSerializer messageSerializer = new RosbridgeMessageSerializer();
            IRosbridgeMessageDispatcher messageDispatcher = new RosbridgeMessageDispatcher(socket, messageSerializer);
            RosPublisher<Twist> publisher = new RosPublisher<Twist>(messageDispatcher, "/turtle1/cmd_vel");

            messageDispatcher.StartAsync().ContinueWith((publish) =>
            {
                publisher.AdvertiseAsync();

            });

            while (true)
            {
                publisher.PublishAsync(new Twist() { angular = new Vector() { x = 10, y = 0, z = 0 }, linear = new Vector() { x = 0, y = 0, z = 0 } });
            }
        }
    }
}
