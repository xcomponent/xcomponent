using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XComponent.Common.ApiContext;
using XComponent.Common.Timeouts;
using XComponent.SwaggerPetstore.Common;
using XComponent.SwaggerPetstore.Common.Senders;
using XComponent.SwaggerPetstore.TriggeredMethod.ServiceClient;
using XComponent.SwaggerPetstore.UserObject;
using XComponent.SwaggerPetstore.UserObject.Models;

namespace XComponent.SwaggerPetstore.TriggeredMethod
{
    public static class LogoutUserOperationTriggeredMethod
    {
        public static void ExecuteOn_SendingRequest_Through_CreateLogoutUserHttpRequest(XComponent.SwaggerPetstore.UserObject.LogoutUserOperation logoutUserOperation, XComponent.SwaggerPetstore.UserObject.LogoutUserOperation logoutUserOperation_PublicMember, object object_InternalMember, Context context, ICreateLogoutUserHttpRequestLogoutUserOperationOnSendingRequestLogoutUserOperationSenderInterface sender)
        {
            XComponent.Common.Clone.XCClone.Clone(logoutUserOperation, logoutUserOperation_PublicMember);

            var task = TriggeredMethodContext.Instance.ServiceClient.LogoutUserWithHttpMessagesAsync();
            task.ContinueWith((Task<Microsoft.Rest.HttpOperationResponse> httpTask) =>
            {
                try
                {
                    logoutUserOperation_PublicMember.Message = httpTask.Result.Response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    logoutUserOperation_PublicMember.HasErrors = !httpTask.Result.Response.IsSuccessStatusCode;
                    if (logoutUserOperation_PublicMember.HasErrors)
                    {
                        sender.ReceiveError_LogoutUserOperation(context, new ErrorResponse());
                    }
                    else
                    {
                        sender.ReceiveSuccess_LogoutUserOperation(context, new SuccessResponse());
                    }
                }
                catch (AggregateException ae)
                {
                    Exception innerexception = ae.InnerException;
                    while (innerexception != null)
                    {
                        TriggeredMethodContext.Instance.LogError(innerexception.Message);
                        innerexception = innerexception.InnerException;
                    }

                    logoutUserOperation_PublicMember.HasErrors = true;
                    sender.ReceiveError_LogoutUserOperation(context, new ErrorResponse());
                }
            });

            // Go to "RequestSent" state..
            sender.SendRequest_LogoutUserOperation(context, new XComponent.Common.Event.DefaultEvent());

            // Send the http request..

        }
    }
}