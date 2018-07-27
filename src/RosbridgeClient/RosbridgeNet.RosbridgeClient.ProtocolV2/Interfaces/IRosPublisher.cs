namespace RosbridgeNet.RosbridgeClient.ProtocolV2.Interfaces
{
    public interface IRosPublisher : Common.Interfaces.IRosPublisher
    {
        string MessageId { get; set; }
    }
}
