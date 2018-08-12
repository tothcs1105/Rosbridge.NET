namespace RosbridgeNet.RosbridgeClient.ProtocolV2.Generics
{
    using System.Threading.Tasks;
    using RosbridgeNet.RosbridgeClient.Common.Extensions;
    using RosbridgeNet.RosbridgeClient.Common.Interfaces;
    using RosbridgeNet.RosbridgeClient.ProtocolV2.Generics.Interfaces;

    public class RosPublisher<TRosMessage> : RosPublisher, IRosPublisher<TRosMessage> where TRosMessage : class, new()
    {
        public RosPublisher(IRosbridgeMessageDispatcher rosbridgeMessageDispatcher, string topic) : base(rosbridgeMessageDispatcher, topic)
        {
            if (this.Type == null)
            {
                this.Type = typeof(TRosMessage).GetRosMessageType();
            }
        }

        public RosPublisher(IRosbridgeMessageDispatcher rosbridgeMessageDispatcher, string topic, string type) : base(rosbridgeMessageDispatcher, topic, type)
        {
        }

        public Task PublishAsync(TRosMessage rosMessage)
        {
            return base.PublishAsync(rosMessage);
        }
    }
}