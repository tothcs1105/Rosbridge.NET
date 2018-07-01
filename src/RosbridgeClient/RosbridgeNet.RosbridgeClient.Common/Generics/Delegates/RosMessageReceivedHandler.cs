namespace RosbridgeNet.RosbridgeClient.Common.Generics.Delegates
{
    using RosbridgeNet.RosbridgeClient.Common.Generics.EventArgs;

    public delegate void RosMessageReceivedHandler<TRosMessage>(object sender, RosMessageReceivedEventArgs<TRosMessage> args) where TRosMessage : class, new();
}
