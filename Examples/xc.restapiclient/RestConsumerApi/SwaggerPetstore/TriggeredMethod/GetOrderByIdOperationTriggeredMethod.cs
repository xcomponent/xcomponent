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
    public static class GetOrderByIdOperationTriggeredMethod
    {
        public static void ExecuteOn_SendingRequest_Through_CreateGetOrderByIdHttpRequest(XComponent.SwaggerPetstore.UserObject.GetOrderByIdOperation getOrderByIdOperation, XComponent.SwaggerPetstore.UserObject.GetOrderByIdOperation getOrderByIdOperation_PublicMember, object object_InternalMember, Context context, ICreateGetOrderByIdHttpRequestGetOrderByIdOperationOnSendingRequestGetOrderByIdOperationSenderInterface sender)
        {
            XComponent.Common.Clone.XCClone.Clone(getOrderByIdOperation, getOrderByIdOperation_PublicMember);

            var task = TriggeredMethodContext.Instance.ServiceClient.GetOrderByIdWithHttpMessagesAsync(getOrderByIdOperation_PublicMember.Event.orderId);
            task.ContinueWith((Task<Microsoft.Rest.HttpOperationResponse<Order>> httpTask) =>
            {
                try
                {
                    getOrderByIdOperation_PublicMember.Message = httpTask.Result.Response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    getOrderByIdOperation_PublicMember.HasErrors = !httpTask.Result.Response.IsSuccessStatusCode;
                    getOrderByIdOperation_PublicMember.OperationResult = httpTask.Result.Body;
                    if (getOrderByIdOperation_PublicMember.HasErrors)
                    {
                        sender.ReceiveError_GetOrderByIdOperation(context, new ErrorResponse());
                    }
                    else
                    {
                        sender.ReceiveSuccess_GetOrderByIdOperation(context, new SuccessResponse());
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

                    getOrderByIdOperation_PublicMember.HasErrors = true;
                    sender.ReceiveError_GetOrderByIdOperation(context, new ErrorResponse());
                }
            });

            // Go to "RequestSent" state..
            sender.SendRequest_GetOrderByIdOperation(context, new XComponent.Common.Event.DefaultEvent());

            // Send the http request..

        }
    }
}