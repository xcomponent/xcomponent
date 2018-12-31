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
    public static class CreateUserOperationTriggeredMethod
    {
        public static void ExecuteOn_SendingRequest_Through_CreateCreateUserHttpRequest(XComponent.SwaggerPetstore.UserObject.CreateUserOperation createUserOperation, XComponent.SwaggerPetstore.UserObject.CreateUserOperation createUserOperation_PublicMember, object object_InternalMember, RuntimeContext context, ICreateCreateUserHttpRequestCreateUserOperationOnSendingRequestCreateUserOperationSenderInterface sender)
        {
            XComponent.Shared.XCClone.Clone(createUserOperation, createUserOperation_PublicMember);

            var task = TriggeredMethodContext.Instance.ServiceClient.CreateUserWithHttpMessagesAsync(createUserOperation_PublicMember.Event.body);
            task.ContinueWith((Task<Microsoft.Rest.HttpOperationResponse> httpTask) =>
            {
                try
                {
                    createUserOperation_PublicMember.Message = httpTask.Result.Response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    createUserOperation_PublicMember.HasErrors = !httpTask.Result.Response.IsSuccessStatusCode;
                    if (createUserOperation_PublicMember.HasErrors)
                    {
                        sender.ReceiveError_CreateUserOperation(context, new ErrorResponse());
                    }
                    else
                    {
                        sender.ReceiveSuccess_CreateUserOperation(context, new SuccessResponse());
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

                    createUserOperation_PublicMember.HasErrors = true;
                    sender.ReceiveError_CreateUserOperation(context, new ErrorResponse());
                }
            });

            // Go to "RequestSent" state..
            sender.SendRequest_CreateUserOperation(context, new XComponent.Common.Event.DefaultEvent());

            // Send the http request..

        }
    }
}