namespace RosbridgeNet.RosbridgeClient.Common.EventArgs
{
    using System;

    public class RosMessageReceivedEventArgs : EventArgs
    {
        public object RosMessage { get; private set; }

        public RosMessageReceivedEventArgs(object rosMessage)
        {
            this.RosMessage = rosMessage;
        }
    }
}
