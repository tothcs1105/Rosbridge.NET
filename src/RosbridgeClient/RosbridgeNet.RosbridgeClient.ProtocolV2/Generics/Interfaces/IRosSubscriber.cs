namespace RosbridgeNet.RosbridgeClient.ProtocolV2.Generics.Interfaces
{
    using RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.Enums;

    public interface IRosSubscriber<TRosMessage> : Common.Generics.Interfaces.IRosSubscriber<TRosMessage> where TRosMessage : class, new()
    {
        MessageCompressionLevel? MessageCompressionLevel { get; }

        int? FragmentSize { get; }

        string MessageId { get; }

        int? ThrottleRate { get; }

        int? QueueLength { get; }
    }
}
