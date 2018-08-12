namespace RosbridgeNet.RosbridgeClient.ProtocolV2.Interfaces
{
    public interface IRosSubscriber : Common.Interfaces.IRosSubscriber, IRosOperator, IFragmentedMessageOperator
    {
        int? ThrottleRate { get; set; }

        int? QueueLength { get; set; }
    }
}
