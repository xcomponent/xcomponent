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
    public static class FindPetsByStatusOperationTriggeredMethod
    {
        public static void ExecuteOn_SendingRequest_Through_CreateFindPetsByStatusHttpRequest(XComponent.SwaggerPetstore.UserObject.FindPetsByStatusOperation findPetsByStatusOperation, XComponent.SwaggerPetstore.UserObject.FindPetsByStatusOperation findPetsByStatusOperation_PublicMember, object object_InternalMember, Context context, ICreateFindPetsByStatusHttpRequestFindPetsByStatusOperationOnSendingRequestFindPetsByStatusOperationSenderInterface sender)
        {
            XComponent.Common.Clone.XCClone.Clone(findPetsByStatusOperation, findPetsByStatusOperation_PublicMember);

            var task = TriggeredMethodContext.Instance.ServiceClient.FindPetsByStatusWithHttpMessagesAsync(findPetsByStatusOperation_PublicMember.Event.status);
            task.ContinueWith((Task<Microsoft.Rest.HttpOperationResponse<System.Collections.Generic.IList<Pet>>> httpTask) =>
            {
                try
                {
                    findPetsByStatusOperation_PublicMember.Message = httpTask.Result.Response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    findPetsByStatusOperation_PublicMember.HasErrors = !httpTask.Result.Response.IsSuccessStatusCode;
                    findPetsByStatusOperation_PublicMember.OperationResult = httpTask.Result.Body;
                    if (findPetsByStatusOperation_PublicMember.HasErrors)
                    {
                        sender.ReceiveError_FindPetsByStatusOperation(context, new ErrorResponse());
                    }
                    else
                    {
                        sender.ReceiveSuccess_FindPetsByStatusOperation(context, new SuccessResponse());
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

                    findPetsByStatusOperation_PublicMember.HasErrors = true;
                    sender.ReceiveError_FindPetsByStatusOperation(context, new ErrorResponse());
                }
            });

            // Go to "RequestSent" state..
            sender.SendRequest_FindPetsByStatusOperation(context, new XComponent.Common.Event.DefaultEvent());

            // Send the http request..

        }
    }
}