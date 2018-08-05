namespace RosbridgeNet.RosbridgeClient.Common.Interfaces
{
    using System.Threading.Tasks;

    public interface IRosServiceClient
    {
        string ServiceName { get; }

        Task<object> CallServiceAsync(object serviceArgs = null, string serviceName = null);
    }
}
