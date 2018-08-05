namespace RosbridgeNet.RosbridgeClient.ProtocolV2.Generics.Delegates
{
    using RosbridgeNet.RosbridgeClient.ProtocolV2.Generics.EventArgs;

    public delegate void RosMessageReceivedHanlder<TRosMessage>(object sender, RosMessageReceivedEventArgs<TRosMessage> args);
}
