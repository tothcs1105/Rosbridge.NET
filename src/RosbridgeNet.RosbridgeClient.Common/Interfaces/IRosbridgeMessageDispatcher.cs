namespace RosbridgeNet.RosbridgeClient.Common.Interfaces
{
    using System;
    using System.Threading.Tasks;
    using RosbridgeNet.RosbridgeClient.Common.Delegates;
    using RosbridgeNet.RosbridgeClient.Common.Enums;

    public interface IRosbridgeMessageDispatcher : IDisposable
    {
        event RosbridgeMessageReceivedHanlder RosbridgeMessageReceived;

        RosbridgeMessageDispatcherStates CurrentState { get; }

        Task StartAsync();

        Task StopAsync();

        Task SendAsync<TRosbridgeMessage>(TRosbridgeMessage rosbridgeMessage) where TRosbridgeMessage : class, new();
    }
}
