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
    public static class AddPetOperationTriggeredMethod
    {
        public static void ExecuteOn_SendingRequest_Through_CreateAddPetHttpRequest(XComponent.SwaggerPetstore.UserObject.AddPetOperation addPetOperation, XComponent.SwaggerPetstore.UserObject.AddPetOperation addPetOperation_PublicMember, object object_InternalMember, RuntimeContext context, ICreateAddPetHttpRequestAddPetOperationOnSendingRequestAddPetOperationSenderInterface sender)
        {
            XComponent.Shared.XCClone.Clone(addPetOperation, addPetOperation_PublicMember);

            var task = TriggeredMethodContext.Instance.ServiceClient.AddPetWithHttpMessagesAsync(addPetOperation_PublicMember.Event.body);
            task.ContinueWith((Task<Microsoft.Rest.HttpOperationResponse> httpTask) =>
            {
                try
                {
                    addPetOperation_PublicMember.Message = httpTask.Result.Response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    addPetOperation_PublicMember.HasErrors = !httpTask.Result.Response.IsSuccessStatusCode;
                    if (addPetOperation_PublicMember.HasErrors)
                    {
                        sender.ReceiveError_AddPetOperation(context, new ErrorResponse());
                    }
                    else
                    {
                        sender.ReceiveSuccess_AddPetOperation(context, new SuccessResponse());
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

                    addPetOperation_PublicMember.HasErrors = true;
                    sender.ReceiveError_AddPetOperation(context, new ErrorResponse());
                }
            });

            // Go to "RequestSent" state..
            sender.SendRequest_AddPetOperation(context, new XComponent.Common.Event.DefaultEvent());

            // Send the http request..

        }
    }
}