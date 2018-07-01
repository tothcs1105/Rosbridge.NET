namespace RosbridgeNet.RosbridgeClient.ProtocolV2.Interfaces
{
    using RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.RosOperations;

    public interface IRosPublisher : Common.Interfaces.IRosPublisher
    {
        RosAdvertiseMessage RosAdvertiseMessage { get; }

        RosUnadvertiseMessage RosUnadvertiseMessage { get; }

        RosPublishMessage RosPublishMessage { get; }
    }
}
