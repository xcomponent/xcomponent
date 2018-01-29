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
    public static class DeleteOrderOperationTriggeredMethod
    {
        public static void ExecuteOn_SendingRequest_Through_CreateDeleteOrderHttpRequest(XComponent.SwaggerPetstore.UserObject.DeleteOrderOperation deleteOrderOperation, XComponent.SwaggerPetstore.UserObject.DeleteOrderOperation deleteOrderOperation_PublicMember, object object_InternalMember, Context context, ICreateDeleteOrderHttpRequestDeleteOrderOperationOnSendingRequestDeleteOrderOperationSenderInterface sender)
        {
            XComponent.Shared.XCClone.Clone(deleteOrderOperation, deleteOrderOperation_PublicMember);

            var task = TriggeredMethodContext.Instance.ServiceClient.DeleteOrderWithHttpMessagesAsync(deleteOrderOperation_PublicMember.Event.orderId);
            task.ContinueWith((Task<Microsoft.Rest.HttpOperationResponse> httpTask) =>
            {
                try
                {
                    deleteOrderOperation_PublicMember.Message = httpTask.Result.Response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    deleteOrderOperation_PublicMember.HasErrors = !httpTask.Result.Response.IsSuccessStatusCode;
                    if (deleteOrderOperation_PublicMember.HasErrors)
                    {
                        sender.ReceiveError_DeleteOrderOperation(context, new ErrorResponse());
                    }
                    else
                    {
                        sender.ReceiveSuccess_DeleteOrderOperation(context, new SuccessResponse());
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

                    deleteOrderOperation_PublicMember.HasErrors = true;
                    sender.ReceiveError_DeleteOrderOperation(context, new ErrorResponse());
                }
            });

            // Go to "RequestSent" state..
            sender.SendRequest_DeleteOrderOperation(context, new XComponent.Common.Event.DefaultEvent());

            // Send the http request..

        }
    }
}