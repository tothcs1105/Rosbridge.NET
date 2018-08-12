namespace RosbridgeNet.RosbridgeClient.ProtocolV2.Generics.Interfaces
{
    using System.Threading.Tasks;
    using RosbridgeNet.RosbridgeClient.ProtocolV2.Interfaces;

    public interface IRosServiceClient<TServiceRequest, TServiceResponse> : IRosServiceClient where TServiceRequest : class, new() where TServiceResponse : class, new()
    {
        Task<TServiceResponse> CallServiceAsync(TServiceRequest serviceArgs = null, string serviceName = null);
    }
}
