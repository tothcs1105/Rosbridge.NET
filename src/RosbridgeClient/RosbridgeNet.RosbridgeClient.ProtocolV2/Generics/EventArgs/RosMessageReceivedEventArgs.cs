namespace RosbridgeNet.RosbridgeClient.ProtocolV2.Generics.EventArgs
{
    public class RosMessageReceivedEventArgs<TRosMessage>
    {
        public TRosMessage RosMessage { get; set; }

        public RosMessageReceivedEventArgs(TRosMessage rosMessage)
        {
            this.RosMessage = rosMessage;
        }
    }
}
