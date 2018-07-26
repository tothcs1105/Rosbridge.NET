namespace RosbridgeNet.RosbridgeClient.Common.Generics.Interfaces
{
    using RosbridgeNet.RosbridgeClient.Common.Interfaces;

    public interface IRosTopicOperator<TRosMessage> : IRosTopicOperator where TRosMessage : class, new()
    {
    }
}
