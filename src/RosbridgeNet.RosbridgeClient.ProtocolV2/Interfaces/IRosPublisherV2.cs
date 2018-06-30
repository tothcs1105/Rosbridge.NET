namespace RosbridgeNet.RosbridgeClient.ProtocolV2.Interfaces
{
    using RosbridgeNet.RosbridgeClient.Common.Interfaces;
    using RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.RosOperations;

    public interface IRosPublisherV2<TRosMessage> : IRosPublisher<TRosMessage>
        where TRosMessage : class, new()
    {
        RosAdvertiseMessage RosAdvertiseMessage { get; }

        RosUnadvertiseMessage RosUnadvertiseMessage { get; }

        RosPublishMessage<TRosMessage> RosPublishMessage { get; }
    }
}
