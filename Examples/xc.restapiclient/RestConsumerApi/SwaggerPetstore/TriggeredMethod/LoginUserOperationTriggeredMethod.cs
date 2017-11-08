using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XComponent.Common.ApiContext;
using XComponent.Common.Timeouts;
using XComponent.Shared;
using XComponent.SwaggerPetstore.Common;
using XComponent.SwaggerPetstore.Common.Senders;
using XComponent.SwaggerPetstore.TriggeredMethod.ServiceClient;
using XComponent.SwaggerPetstore.UserObject;
using XComponent.SwaggerPetstore.UserObject.Models;

namespace XComponent.SwaggerPetstore.TriggeredMethod
{
    public static class LoginUserOperationTriggeredMethod
    {
        public static void ExecuteOn_SendingRequest_Through_CreateLoginUserHttpRequest(XComponent.SwaggerPetstore.UserObject.LoginUserOperation loginUserOperation, XComponent.SwaggerPetstore.UserObject.LoginUserOperation loginUserOperation_PublicMember, object object_InternalMember, Context context, ICreateLoginUserHttpRequestLoginUserOperationOnSendingRequestLoginUserOperationSenderInterface sender)
        {
            XComponent.Shared.XCClone.Clone(loginUserOperation, loginUserOperation_PublicMember);

            var task = TriggeredMethodContext.Instance.ServiceClient.LoginUserWithHttpMessagesAsync(loginUserOperation_PublicMember.Event.username, loginUserOperation_PublicMember.Event.password);
            task.ContinueWith((Task<Microsoft.Rest.HttpOperationResponse<string, LoginUserHeaders>> httpTask) =>
            {
                try
                {
                    loginUserOperation_PublicMember.Message = httpTask.Result.Response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    loginUserOperation_PublicMember.HasErrors = !httpTask.Result.Response.IsSuccessStatusCode;
                    loginUserOperation_PublicMember.OperationResult = httpTask.Result.Body;
                    if (loginUserOperation_PublicMember.HasErrors)
                    {
                        sender.ReceiveError_LoginUserOperation(context, new ErrorResponse());
                    }
                    else
                    {
                        sender.ReceiveSuccess_LoginUserOperation(context, new SuccessResponse());
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

                    loginUserOperation_PublicMember.HasErrors = true;
                    sender.ReceiveError_LoginUserOperation(context, new ErrorResponse());
                }
            });

            // Go to "RequestSent" state..
            sender.SendRequest_LoginUserOperation(context, new XComponent.Common.Event.DefaultEvent());

            // Send the http request..

        }
    }
}