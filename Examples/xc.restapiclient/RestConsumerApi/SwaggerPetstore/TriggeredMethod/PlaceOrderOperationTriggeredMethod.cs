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
    public static class PlaceOrderOperationTriggeredMethod
    {
        public static void ExecuteOn_SendingRequest_Through_CreatePlaceOrderHttpRequest(XComponent.SwaggerPetstore.UserObject.PlaceOrderOperation placeOrderOperation, XComponent.SwaggerPetstore.UserObject.PlaceOrderOperation placeOrderOperation_PublicMember, object object_InternalMember, Context context, ICreatePlaceOrderHttpRequestPlaceOrderOperationOnSendingRequestPlaceOrderOperationSenderInterface sender)
        {
            XComponent.Shared.XCClone.Clone(placeOrderOperation, placeOrderOperation_PublicMember);

            var task = TriggeredMethodContext.Instance.ServiceClient.PlaceOrderWithHttpMessagesAsync(placeOrderOperation_PublicMember.Event.body);
            task.ContinueWith((Task<Microsoft.Rest.HttpOperationResponse<Order>> httpTask) =>
            {
                try
                {
                    placeOrderOperation_PublicMember.Message = httpTask.Result.Response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    placeOrderOperation_PublicMember.HasErrors = !httpTask.Result.Response.IsSuccessStatusCode;
                    placeOrderOperation_PublicMember.OperationResult = httpTask.Result.Body;
                    if (placeOrderOperation_PublicMember.HasErrors)
                    {
                        sender.ReceiveError_PlaceOrderOperation(context, new ErrorResponse());
                    }
                    else
                    {
                        sender.ReceiveSuccess_PlaceOrderOperation(context, new SuccessResponse());
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

                    placeOrderOperation_PublicMember.HasErrors = true;
                    sender.ReceiveError_PlaceOrderOperation(context, new ErrorResponse());
                }
            });

            // Go to "RequestSent" state..
            sender.SendRequest_PlaceOrderOperation(context, new XComponent.Common.Event.DefaultEvent());

            // Send the http request..

        }
    }
}