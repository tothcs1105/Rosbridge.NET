namespace RosbridgeNet.RosbridgeClient.ProtocolV2.Interfaces
{
    public interface IRosSubscriber : Common.Interfaces.IRosSubscriber, IRosOperator, IFragmentedRosMessageOperator
    {
        int? ThrottleRate { get; set; }

        int? QueueLength { get; set; }
    }
}
