namespace RosbridgeNet.RosbridgeClient.ProtocolV2.Generics
{
    using RosbridgeNet.RosbridgeClient.Common.Extensions;
    using RosbridgeNet.RosbridgeClient.Common.Interfaces;
    using RosbridgeNet.RosbridgeClient.ProtocolV2.Generics.Delegates;
    using RosbridgeNet.RosbridgeClient.ProtocolV2.Generics.EventArgs;
    using RosbridgeNet.RosbridgeClient.ProtocolV2.Generics.Interfaces;

    public class RosSubscriber<TRosMessage> : RosSubscriber, IRosSubscriber<TRosMessage> where TRosMessage : class, new()
    {
        public RosSubscriber(IRosbridgeMessageDispatcher rosbridgeMessageDispatcher, string topic) : base(rosbridgeMessageDispatcher, topic)
        {
            if (this.Type == null)
            {
                this.Type = typeof(TRosMessage).GetRosMessageType();
            }

            base.RosMessageReceived += RosMessageReceivedHandler;
        }

        public RosSubscriber(IRosbridgeMessageDispatcher rosbridgeMessageDispatcher, string topic, string type) : base(rosbridgeMessageDispatcher, topic, type)
        {
            base.RosMessageReceived += RosMessageReceivedHandler;
        }

        public new event RosMessageReceivedHanlder<TRosMessage> RosMessageReceived;

        private void RosMessageReceivedHandler(object sender, Common.EventArgs.RosMessageReceivedEventArgs args)
        {
            if (args != null)
            {
                TRosMessage rosMessage = args.RosMessage as TRosMessage;

                if (rosMessage != null)
                {
                    this.RosMessageReceived?.Invoke(this, new RosMessageReceivedEventArgs<TRosMessage>(rosMessage));
                }
            }
        }
    }
}
