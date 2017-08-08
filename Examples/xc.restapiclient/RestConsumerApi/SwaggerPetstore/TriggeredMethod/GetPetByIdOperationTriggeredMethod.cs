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
    public static class GetPetByIdOperationTriggeredMethod
    {
        public static void ExecuteOn_SendingRequest_Through_CreateGetPetByIdHttpRequest(XComponent.SwaggerPetstore.UserObject.GetPetByIdOperation getPetByIdOperation, XComponent.SwaggerPetstore.UserObject.GetPetByIdOperation getPetByIdOperation_PublicMember, object object_InternalMember, Context context, ICreateGetPetByIdHttpRequestGetPetByIdOperationOnSendingRequestGetPetByIdOperationSenderInterface sender)
        {
            XComponent.Shared.XCClone.Clone(getPetByIdOperation, getPetByIdOperation_PublicMember);

            var task = TriggeredMethodContext.Instance.ServiceClient.GetPetByIdWithHttpMessagesAsync(getPetByIdOperation_PublicMember.Event.petId);
            task.ContinueWith((Task<Microsoft.Rest.HttpOperationResponse<Pet>> httpTask) =>
            {
                try
                {
                    getPetByIdOperation_PublicMember.Message = httpTask.Result.Response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    getPetByIdOperation_PublicMember.HasErrors = !httpTask.Result.Response.IsSuccessStatusCode;
                    getPetByIdOperation_PublicMember.OperationResult = httpTask.Result.Body;
                    if (getPetByIdOperation_PublicMember.HasErrors)
                    {
                        sender.ReceiveError_GetPetByIdOperation(context, new ErrorResponse());
                    }
                    else
                    {
                        sender.ReceiveSuccess_GetPetByIdOperation(context, new SuccessResponse());
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

                    getPetByIdOperation_PublicMember.HasErrors = true;
                    sender.ReceiveError_GetPetByIdOperation(context, new ErrorResponse());
                }
            });

            // Go to "RequestSent" state..
            sender.SendRequest_GetPetByIdOperation(context, new XComponent.Common.Event.DefaultEvent());

            // Send the http request..

        }
    }
}