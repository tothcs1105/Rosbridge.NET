namespace RosbridgeNet.RosbridgeClient.ProtocolV2.Generics
{
    using System.Threading.Tasks;
    using Newtonsoft.Json.Linq;
    using RosbridgeNet.RosbridgeClient.Common.Interfaces;
    using RosbridgeNet.RosbridgeClient.ProtocolV2.Generics.Interfaces;

    public class RosServiceClient<TServiceRequest, TServiceResponse> : RosServiceClient, IRosServiceClient<TServiceRequest, TServiceResponse> where TServiceRequest : class, new() where TServiceResponse : class, new()
    {
        public RosServiceClient(IRosbridgeMessageDispatcher rosbridgeMessageDispatcher, string serviceName = null) : base(rosbridgeMessageDispatcher, serviceName)
        {
        }

        public Task<TServiceResponse> CallServiceAsync(TServiceRequest serviceArgs = null, string serviceName = null)
        {
            TaskCompletionSource<TServiceResponse> taskCompletion = new TaskCompletionSource<TServiceResponse>();

            JObject result = base.CallServiceAsyncProtected(serviceArgs, serviceName).Result;

            if (result != null)
            {
                TServiceResponse serviceResponse = result.ToObject<TServiceResponse>();

                taskCompletion.SetResult(serviceResponse);
            }
            else
            {
                taskCompletion.SetResult(null);
            }

            return taskCompletion.Task;
        }
    }
}
