namespace RosbridgeNet.RosbridgeClient.ProtocolV2.Interfaces
{
    using RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.Enums;

    public interface IRosSubscriber : Common.Interfaces.IRosSubscriber
    {
        MessageCompressionLevel? MessageCompressionLevel { get; }

        int? FragmentSize { get; }

        string Id { get; }

        int? ThrottleRate { get; }

        int? QueueLength { get; }
    }
}
