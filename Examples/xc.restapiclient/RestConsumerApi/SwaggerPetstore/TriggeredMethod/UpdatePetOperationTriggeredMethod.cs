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
    public static class UpdatePetOperationTriggeredMethod
    {
        public static void ExecuteOn_SendingRequest_Through_CreateUpdatePetHttpRequest(XComponent.SwaggerPetstore.UserObject.UpdatePetOperation updatePetOperation, XComponent.SwaggerPetstore.UserObject.UpdatePetOperation updatePetOperation_PublicMember, object object_InternalMember, Context context, ICreateUpdatePetHttpRequestUpdatePetOperationOnSendingRequestUpdatePetOperationSenderInterface sender)
        {
            XComponent.Shared.XCClone.Clone(updatePetOperation, updatePetOperation_PublicMember);

            var task = TriggeredMethodContext.Instance.ServiceClient.UpdatePetWithHttpMessagesAsync(updatePetOperation_PublicMember.Event.body);
            task.ContinueWith((Task<Microsoft.Rest.HttpOperationResponse> httpTask) =>
            {
                try
                {
                    updatePetOperation_PublicMember.Message = httpTask.Result.Response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    updatePetOperation_PublicMember.HasErrors = !httpTask.Result.Response.IsSuccessStatusCode;
                    if (updatePetOperation_PublicMember.HasErrors)
                    {
                        sender.ReceiveError_UpdatePetOperation(context, new ErrorResponse());
                    }
                    else
                    {
                        sender.ReceiveSuccess_UpdatePetOperation(context, new SuccessResponse());
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

                    updatePetOperation_PublicMember.HasErrors = true;
                    sender.ReceiveError_UpdatePetOperation(context, new ErrorResponse());
                }
            });

            // Go to "RequestSent" state..
            sender.SendRequest_UpdatePetOperation(context, new XComponent.Common.Event.DefaultEvent());

            // Send the http request..

        }
    }
}