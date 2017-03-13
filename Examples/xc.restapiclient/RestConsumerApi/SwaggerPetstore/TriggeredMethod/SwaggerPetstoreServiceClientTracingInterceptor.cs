namespace XComponent.SwaggerPetstore.TriggeredMethod
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.Rest;

    public class SwaggerPetstoreServiceClientTracingInterceptor : IServiceClientTracingInterceptor
    {
        public void Configuration(string source, string name, string value)
        {
            var message = string.Format("Configuration. Source = {0}, name = {1}, value = {2}", source, name, value);

            TriggeredMethodContext.Instance.LogInfo(message);
        }

        public void EnterMethod(string invocationId, object instance, string method, IDictionary<string, object> parameters)
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Format("Entered {0} method (invocation Id = {1})", method, invocationId));

            if (parameters != null)
            {
                sb.AppendLine("Parameters:");

                foreach (var parameter in parameters)
                {
                    sb.AppendLine(string.Format("{0} = {1}", parameter.Key, parameter.Value));
                }
            }

            TriggeredMethodContext.Instance.LogInfo(sb.ToString());
        }

        public void ExitMethod(string invocationId, object returnValue)
        {
            var message = string.Format("Exited method (invocationId = {0}). Return value = {1}", invocationId, returnValue);

            TriggeredMethodContext.Instance.LogInfo(message);
        }

        public void Information(string message)
        {
            TriggeredMethodContext.Instance.LogInfo(message);
        }

        public void ReceiveResponse(string invocationId, System.Net.Http.HttpResponseMessage response)
        {
            var message = string.Format("Received response (invocation Id = {0}) : {1}", invocationId, response);

            TriggeredMethodContext.Instance.LogInfo(message);
        }

        public void SendRequest(string invocationId, System.Net.Http.HttpRequestMessage request)
        {
            var message = string.Format("Sending request (invocation Id = {0}) : {1}", invocationId, request);

            TriggeredMethodContext.Instance.LogInfo(message);
        }

        public void TraceError(string invocationId, Exception exception)
        {
            var sb = new StringBuilder();

            sb.AppendLine(string.Format("Error (invocation Id = {0})", invocationId));
            if (exception != null)
            {
                sb.AppendLine(exception.Message);
                sb.AppendLine("Stack trace:");
                sb.AppendLine(exception.StackTrace);
            }

            TriggeredMethodContext.Instance.LogError(sb.ToString());
        }
    }
}
