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
    public static class GetInventoryOperationTriggeredMethod
    {
        public static void ExecuteOn_SendingRequest_Through_CreateGetInventoryHttpRequest(XComponent.SwaggerPetstore.UserObject.GetInventoryOperation getInventoryOperation, XComponent.SwaggerPetstore.UserObject.GetInventoryOperation getInventoryOperation_PublicMember, object object_InternalMember, Context context, ICreateGetInventoryHttpRequestGetInventoryOperationOnSendingRequestGetInventoryOperationSenderInterface sender)
        {
            XComponent.Shared.XCClone.Clone(getInventoryOperation, getInventoryOperation_PublicMember);

            var task = TriggeredMethodContext.Instance.ServiceClient.GetInventoryWithHttpMessagesAsync();
            task.ContinueWith((Task<Microsoft.Rest.HttpOperationResponse<System.Collections.Generic.IDictionary<string, int?>>> httpTask) =>
            {
                try
                {
                    getInventoryOperation_PublicMember.Message = httpTask.Result.Response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    getInventoryOperation_PublicMember.HasErrors = !httpTask.Result.Response.IsSuccessStatusCode;
                    getInventoryOperation_PublicMember.OperationResult = httpTask.Result.Body;
                    if (getInventoryOperation_PublicMember.HasErrors)
                    {
                        sender.ReceiveError_GetInventoryOperation(context, new ErrorResponse());
                    }
                    else
                    {
                        sender.ReceiveSuccess_GetInventoryOperation(context, new SuccessResponse());
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

                    getInventoryOperation_PublicMember.HasErrors = true;
                    sender.ReceiveError_GetInventoryOperation(context, new ErrorResponse());
                }
            });

            // Go to "RequestSent" state..
            sender.SendRequest_GetInventoryOperation(context, new XComponent.Common.Event.DefaultEvent());

            // Send the http request..

        }
    }
}