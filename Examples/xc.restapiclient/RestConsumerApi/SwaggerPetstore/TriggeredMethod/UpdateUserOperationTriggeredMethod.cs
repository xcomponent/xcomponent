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
    public static class UpdateUserOperationTriggeredMethod
    {
        public static void ExecuteOn_SendingRequest_Through_CreateUpdateUserHttpRequest(XComponent.SwaggerPetstore.UserObject.UpdateUserOperation updateUserOperation, XComponent.SwaggerPetstore.UserObject.UpdateUserOperation updateUserOperation_PublicMember, object object_InternalMember, RuntimeContext context, ICreateUpdateUserHttpRequestUpdateUserOperationOnSendingRequestUpdateUserOperationSenderInterface sender)
        {
            XComponent.Shared.XCClone.Clone(updateUserOperation, updateUserOperation_PublicMember);

            var task = TriggeredMethodContext.Instance.ServiceClient.UpdateUserWithHttpMessagesAsync(updateUserOperation_PublicMember.Event.username, updateUserOperation_PublicMember.Event.body);
            task.ContinueWith((Task<Microsoft.Rest.HttpOperationResponse> httpTask) =>
            {
                try
                {
                    updateUserOperation_PublicMember.Message = httpTask.Result.Response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    updateUserOperation_PublicMember.HasErrors = !httpTask.Result.Response.IsSuccessStatusCode;
                    if (updateUserOperation_PublicMember.HasErrors)
                    {
                        sender.ReceiveError_UpdateUserOperation(context, new ErrorResponse());
                    }
                    else
                    {
                        sender.ReceiveSuccess_UpdateUserOperation(context, new SuccessResponse());
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

                    updateUserOperation_PublicMember.HasErrors = true;
                    sender.ReceiveError_UpdateUserOperation(context, new ErrorResponse());
                }
            });

            // Go to "RequestSent" state..
            sender.SendRequest_UpdateUserOperation(context, new XComponent.Common.Event.DefaultEvent());

            // Send the http request..

        }
    }
}