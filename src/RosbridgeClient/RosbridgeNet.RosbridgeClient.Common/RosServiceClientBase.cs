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
            if (string.IsNullOrWhiteSpace(this.ServiceName) && string.IsNullOrWhiteSpace(serviceName))
            {
                throw new InvalidOperationException($"Service is not defined!");
            }

            TaskCompletionSource<object> taskCompletion = new TaskCompletionSource<object>();

            RosbridgeMessageReceivedHanlder rosbridgeMessageReceivedHanlder = (object sender, RosbridgeMessageReceivedEventArgs eventArgs) =>
            {
                if (eventArgs != null)
                {
                    taskCompletion.SetResult(this.HandleRosbridgeMessage(eventArgs.RosbridgeMessage, serviceName));
                }
                else
                {
                    taskCompletion.SetResult(null);
                }
            };

            this.rosbridgeMessageDispatcher.RosbridgeMessageReceived += rosbridgeMessageReceivedHanlder;

            Task.Run(async () =>
            {
                TServiceCall serviceCallMessage = this.CreateServiceCallMessage(serviceArgs, serviceName);

                await this.rosbridgeMessageDispatcher.SendAsync(serviceCallMessage);

                this.rosbridgeMessageDispatcher.RosbridgeMessageReceived -= rosbridgeMessageReceivedHanlder;
            });

            return taskCompletion.Task;
        }

        protected abstract TServiceCall CreateServiceCallMessage(object serviceArgs = null, string serviceName = null);

        protected abstract object HandleRosbridgeMessage(JObject rosbridgeMessage, string serviceName = null);
    }
}