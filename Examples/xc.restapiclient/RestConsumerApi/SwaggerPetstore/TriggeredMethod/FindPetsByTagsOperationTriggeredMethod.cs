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
    public static class FindPetsByTagsOperationTriggeredMethod
    {
        public static void ExecuteOn_SendingRequest_Through_CreateFindPetsByTagsHttpRequest(XComponent.SwaggerPetstore.UserObject.FindPetsByTagsOperation findPetsByTagsOperation, XComponent.SwaggerPetstore.UserObject.FindPetsByTagsOperation findPetsByTagsOperation_PublicMember, object object_InternalMember, Context context, ICreateFindPetsByTagsHttpRequestFindPetsByTagsOperationOnSendingRequestFindPetsByTagsOperationSenderInterface sender)
        {
            XComponent.Common.Clone.XCClone.Clone(findPetsByTagsOperation, findPetsByTagsOperation_PublicMember);

            var task = TriggeredMethodContext.Instance.ServiceClient.FindPetsByTagsWithHttpMessagesAsync(findPetsByTagsOperation_PublicMember.Event.tags);
            task.ContinueWith((Task<Microsoft.Rest.HttpOperationResponse<System.Collections.Generic.IList<Pet>>> httpTask) =>
            {
                try
                {
                    findPetsByTagsOperation_PublicMember.Message = httpTask.Result.Response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    findPetsByTagsOperation_PublicMember.HasErrors = !httpTask.Result.Response.IsSuccessStatusCode;
                    findPetsByTagsOperation_PublicMember.OperationResult = httpTask.Result.Body;
                    if (findPetsByTagsOperation_PublicMember.HasErrors)
                    {
                        sender.ReceiveError_FindPetsByTagsOperation(context, new ErrorResponse());
                    }
                    else
                    {
                        sender.ReceiveSuccess_FindPetsByTagsOperation(context, new SuccessResponse());
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

                    findPetsByTagsOperation_PublicMember.HasErrors = true;
                    sender.ReceiveError_FindPetsByTagsOperation(context, new ErrorResponse());
                }
            });

            // Go to "RequestSent" state..
            sender.SendRequest_FindPetsByTagsOperation(context, new XComponent.Common.Event.DefaultEvent());

            // Send the http request..

        }
    }
}