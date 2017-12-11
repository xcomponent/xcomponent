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
    public static class UpdatePetWithFormOperationTriggeredMethod
    {
        public static void ExecuteOn_SendingRequest_Through_CreateUpdatePetWithFormHttpRequest(XComponent.SwaggerPetstore.UserObject.UpdatePetWithFormOperation updatePetWithFormOperation, XComponent.SwaggerPetstore.UserObject.UpdatePetWithFormOperation updatePetWithFormOperation_PublicMember, object object_InternalMember, Context context, ICreateUpdatePetWithFormHttpRequestUpdatePetWithFormOperationOnSendingRequestUpdatePetWithFormOperationSenderInterface sender)
        {
            XComponent.Common.Clone.XCClone.Clone(updatePetWithFormOperation, updatePetWithFormOperation_PublicMember);

            var task = TriggeredMethodContext.Instance.ServiceClient.UpdatePetWithFormWithHttpMessagesAsync(updatePetWithFormOperation_PublicMember.Event.petId, updatePetWithFormOperation_PublicMember.Event.name, updatePetWithFormOperation_PublicMember.Event.status);
            task.ContinueWith((Task<Microsoft.Rest.HttpOperationResponse> httpTask) =>
            {
                try
                {
                    updatePetWithFormOperation_PublicMember.Message = httpTask.Result.Response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    updatePetWithFormOperation_PublicMember.HasErrors = !httpTask.Result.Response.IsSuccessStatusCode;
                    if (updatePetWithFormOperation_PublicMember.HasErrors)
                    {
                        sender.ReceiveError_UpdatePetWithFormOperation(context, new ErrorResponse());
                    }
                    else
                    {
                        sender.ReceiveSuccess_UpdatePetWithFormOperation(context, new SuccessResponse());
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

                    updatePetWithFormOperation_PublicMember.HasErrors = true;
                    sender.ReceiveError_UpdatePetWithFormOperation(context, new ErrorResponse());
                }
            });

            // Go to "RequestSent" state..
            sender.SendRequest_UpdatePetWithFormOperation(context, new XComponent.Common.Event.DefaultEvent());

            // Send the http request..

        }
    }
}