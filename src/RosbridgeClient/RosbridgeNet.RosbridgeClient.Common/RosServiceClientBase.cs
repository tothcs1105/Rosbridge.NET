namespace RosbridgeNet.RosbridgeClient.Common
{
    using System;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Linq;
    using RosbridgeNet.RosbridgeClient.Common.Delegates;
    using RosbridgeNet.RosbridgeClient.Common.EventArgs;
    using RosbridgeNet.RosbridgeClient.Common.Interfaces;

    public abstract class RosServiceClientBase<TServiceCall> : IRosServiceClient where TServiceCall : class, new()
    {
        private readonly IRosbridgeMessageDispatcher rosbridgeMessageDispatcher;

        public RosServiceClientBase(IRosbridgeMessageDispatcher rosbridgeMessageDispatcher, string serviceName = null)
        {
            if (rosbridgeMessageDispatcher == null)
            {
                throw new ArgumentNullException(nameof(rosbridgeMessageDispatcher));
            }

            this.rosbridgeMessageDispatcher = rosbridgeMessageDispatcher;
            this.ServiceName = serviceName;
        }

        public string ServiceName
        {
            get; private set;
        }

        public Task<object> CallServiceAsync(object serviceArgs = null, string serviceName = null)
        {
            TaskCompletionSource<object> taskCompletionSource = new TaskCompletionSource<object>();

            JObject serviceResponse = this.CallServiceAsyncProtected(serviceArgs, serviceName).Result;

            object serviceResponseObject = serviceResponse.ToObject<object>();

            taskCompletionSource.SetResult(serviceResponseObject);

            return taskCompletionSource.Task;
        }

        protected Task<JObject> CallServiceAsyncProtected(object serviceArgs = null, string serviceName = null)
        {
            if (string.IsNullOrWhiteSpace(this.ServiceName) && string.IsNullOrWhiteSpace(serviceName))
            {
                throw new InvalidOperationException($"Service is not defined!");
            }

            TaskCompletionSource<JObject> taskCompletionSource = new TaskCompletionSource<JObject>();

            RosbridgeMessageReceivedHanlder rosbridgeMessageReceivedHandler = (object sender, RosbridgeMessageReceivedEventArgs eventArgs) =>
            {
                if (eventArgs != null)
                {
                    JObject rosMessage = null;

                    bool rosbridgeMessageHandled = false;

                    try
                    {
                        rosbridgeMessageHandled = this.HandleRosbridgeMessage(eventArgs.RosbridgeMessage, ref rosMessage, serviceName);
                    }
                    catch (Exception e)
                    {
                        taskCompletionSource.SetException(e);
                    }

                    if (rosbridgeMessageHandled)
                    {
                        taskCompletionSource.SetResult(rosMessage);
                    }
                }
            };

            this.rosbridgeMessageDispatcher.RosbridgeMessageReceived += rosbridgeMessageReceivedHandler;

            Task.Run(async () =>
            {
                TServiceCall serviceCallMessage = this.CreateServiceCallMessage(serviceArgs, serviceName);

                await this.rosbridgeMessageDispatcher.SendAsync(serviceCallMessage);

                await taskCompletionSource.Task;

                this.rosbridgeMessageDispatcher.RosbridgeMessageReceived -= rosbridgeMessageReceivedHandler;
            });

            return taskCompletionSource.Task;
        }

        protected abstract TServiceCall CreateServiceCallMessage(object serviceArgs = null, string serviceName = null);

        protected abstract bool HandleRosbridgeMessage(JObject rosbridgeMessage, ref JObject rosMessage, string serviceName = null);
    }
}