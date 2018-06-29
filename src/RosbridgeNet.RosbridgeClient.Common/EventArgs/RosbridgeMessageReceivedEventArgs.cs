namespace RosbridgeNet.RosbridgeClient.Common.EventArgs
{
    using System;
    using Newtonsoft.Json.Linq;

    public class RosbridgeMessageReceivedEventArgs : EventArgs
    {
        public JObject RosbridgeMessage { get; private set; }

        public RosbridgeMessageReceivedEventArgs(JObject rosbridgeMessage)
        {
            this.RosbridgeMessage = rosbridgeMessage;
        }
    }
}
