namespace RosbridgeNet.RosbridgeClient.Common.Generics.EventArgs
{
    using System;

    public class RosMessageReceivedEventArgs<TRosMessage> : EventArgs where TRosMessage : class, new()
    {
        public TRosMessage RosMessage { get; private set; }

        public RosMessageReceivedEventArgs(TRosMessage rosMessage)
        {
            if (rosMessage == null)
            {
                throw new ArgumentNullException(nameof(rosMessage));
            }

            this.RosMessage = rosMessage;
        }
    }
}
