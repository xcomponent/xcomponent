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
    public static class DeleteUserOperationTriggeredMethod
    {
        public static void ExecuteOn_SendingRequest_Through_CreateDeleteUserHttpRequest(XComponent.SwaggerPetstore.UserObject.DeleteUserOperation deleteUserOperation, XComponent.SwaggerPetstore.UserObject.DeleteUserOperation deleteUserOperation_PublicMember, object object_InternalMember, Context context, ICreateDeleteUserHttpRequestDeleteUserOperationOnSendingRequestDeleteUserOperationSenderInterface sender)
        {
            XComponent.Shared.XCClone.Clone(deleteUserOperation, deleteUserOperation_PublicMember);

            var task = TriggeredMethodContext.Instance.ServiceClient.DeleteUserWithHttpMessagesAsync(deleteUserOperation_PublicMember.Event.username);
            task.ContinueWith((Task<Microsoft.Rest.HttpOperationResponse> httpTask) =>
            {
                try
                {
                    deleteUserOperation_PublicMember.Message = httpTask.Result.Response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    deleteUserOperation_PublicMember.HasErrors = !httpTask.Result.Response.IsSuccessStatusCode;
                    if (deleteUserOperation_PublicMember.HasErrors)
                    {
                        sender.ReceiveError_DeleteUserOperation(context, new ErrorResponse());
                    }
                    else
                    {
                        sender.ReceiveSuccess_DeleteUserOperation(context, new SuccessResponse());
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

                    deleteUserOperation_PublicMember.HasErrors = true;
                    sender.ReceiveError_DeleteUserOperation(context, new ErrorResponse());
                }
            });

            // Go to "RequestSent" state..
            sender.SendRequest_DeleteUserOperation(context, new XComponent.Common.Event.DefaultEvent());

            // Send the http request..

        }
    }
}