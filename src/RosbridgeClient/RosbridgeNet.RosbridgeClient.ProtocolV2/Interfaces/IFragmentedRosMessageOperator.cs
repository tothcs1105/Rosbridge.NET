namespace RosbridgeNet.RosbridgeClient.ProtocolV2.Interfaces
{
    using RosbridgeNet.RosbridgeClient.ProtocolV2.RosbridgeMessages.Enums;

    public interface IFragmentedRosMessageOperator
    {
        MessageCompressionLevel? MessageCompressionLevel { get; set; }

        int? FragmentSize { get; set; }
    }
}
