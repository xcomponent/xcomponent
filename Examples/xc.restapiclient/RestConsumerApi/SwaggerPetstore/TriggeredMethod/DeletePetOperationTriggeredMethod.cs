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
    public static class DeletePetOperationTriggeredMethod
    {
        public static void ExecuteOn_SendingRequest_Through_CreateDeletePetHttpRequest(XComponent.SwaggerPetstore.UserObject.DeletePetOperation deletePetOperation, XComponent.SwaggerPetstore.UserObject.DeletePetOperation deletePetOperation_PublicMember, object object_InternalMember, Context context, ICreateDeletePetHttpRequestDeletePetOperationOnSendingRequestDeletePetOperationSenderInterface sender)
        {
            XComponent.Common.Clone.XCClone.Clone(deletePetOperation, deletePetOperation_PublicMember);

            var task = TriggeredMethodContext.Instance.ServiceClient.DeletePetWithHttpMessagesAsync(deletePetOperation_PublicMember.Event.petId, deletePetOperation_PublicMember.Event.apiKey);
            task.ContinueWith((Task<Microsoft.Rest.HttpOperationResponse> httpTask) =>
            {
                try
                {
                    deletePetOperation_PublicMember.Message = httpTask.Result.Response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    deletePetOperation_PublicMember.HasErrors = !httpTask.Result.Response.IsSuccessStatusCode;
                    if (deletePetOperation_PublicMember.HasErrors)
                    {
                        sender.ReceiveError_DeletePetOperation(context, new ErrorResponse());
                    }
                    else
                    {
                        sender.ReceiveSuccess_DeletePetOperation(context, new SuccessResponse());
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

                    deletePetOperation_PublicMember.HasErrors = true;
                    sender.ReceiveError_DeletePetOperation(context, new ErrorResponse());
                }
            });

            // Go to "RequestSent" state..
            sender.SendRequest_DeletePetOperation(context, new XComponent.Common.Event.DefaultEvent());

            // Send the http request..

        }
    }
}