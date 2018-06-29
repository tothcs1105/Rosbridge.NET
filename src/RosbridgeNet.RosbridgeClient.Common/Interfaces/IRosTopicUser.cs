namespace RosbridgeNet.RosbridgeClient.Common.Interfaces
{
    public interface IRosTopicUser<TRosMessage> where TRosMessage : class, new()
    {
        string Topic { get; }

        string Type { get; }
    }
}
