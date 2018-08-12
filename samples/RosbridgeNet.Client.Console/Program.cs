namespace RosbridgeNet.Client.Console
{
    using System;
    using System.Net.WebSockets;
    using System.Threading;
    using RosbridgeNet.RosbridgeClient.Common;
    using RosbridgeNet.RosbridgeClient.Common.Interfaces;
    using RosbridgeNet.RosbridgeClient.ProtocolV2;
    using RosbridgeNet.RosbridgeClient.ProtocolV2.Generics;
    using RosbridgeNet.RosbridgeClient.ProtocolV2.Generics.Interfaces;

    class Program
    {
        static void Main(string[] args)
        {
            string webSocketUri = "ws://localhost:9090";
            CancellationTokenSource cts = new CancellationTokenSource();

            IRosbridgeMessageDispatcher messageDispatcher = Connect(new Uri(webSocketUri), cts);


            Subscribe(messageDispatcher);
            var publisher = CreatePublisher(messageDispatcher);

            IRosServiceClient<object, object> serviceClient = new RosServiceClient<object, object>(messageDispatcher, "/clear");

            publisher.PublishAsync(new Twist()
            {
                linear = new Vector()
                {
                    x = -5,
                    y = 0,
                    z = 0
                },
                angular = new Vector()
                {
                    x = 0,
                    y = 0,
                    z = 0
                }
            });

            serviceClient.CallServiceAsync().Wait();

            while (true)
            {
                Thread.Sleep(3000);
            }

        }

        static RosPublisher<Twist> CreatePublisher(IRosbridgeMessageDispatcher messageDispatcher)
        {
            RosPublisher<Twist> publisher = new RosPublisher<Twist>(messageDispatcher, "/turtle1/cmd_vel");
            publisher.AdvertiseAsync();

            return publisher;
        }

        static void Subscribe(IRosbridgeMessageDispatcher messageDispatcher)
        {
            RosSubscriber<Twist> subscriber = new RosSubscriber<Twist>(messageDispatcher, "/turtle1/cmd_vel");

            subscriber.RosMessageReceived += (s, e) => { Console.WriteLine(e.RosMessage); };

            subscriber.SubscribeAsync();
        }

        static IRosbridgeMessageDispatcher Connect(Uri webSocketAddress, CancellationTokenSource cancellationTokenSource)
        {
            ISocket socket = new Socket(new ClientWebSocket(), webSocketAddress, cancellationTokenSource);
            IRosbridgeMessageSerializer messageSerializer = new RosbridgeMessageSerializer();
            IRosbridgeMessageDispatcher messageDispatcher = new RosbridgeMessageDispatcher(socket, messageSerializer);

            messageDispatcher.StartAsync().Wait();

            return messageDispatcher;
        }

    }

    public class Spawn
    {
        public float x { get; set; }
        public float y { get; set; }
        public float theta { get; set; }
        public string name { get; set; }
    }

    public class SpawnResponse
    {
        public string name { get; set; }
    }
}
