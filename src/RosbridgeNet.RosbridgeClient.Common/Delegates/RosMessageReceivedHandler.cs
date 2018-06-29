namespace RosbridgeNet.RosbridgeClient.Common.Delegates
{
    using RosbridgeNet.RosbridgeClient.Common.EventArgs;

    public delegate void RosMessageReceivedHandler<TRosMessage>(object sender, RosMessageReceivedEventArgs<TRosMessage> args) where TRosMessage : class, new();
}
