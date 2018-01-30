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
    public static class GetUserByNameOperationTriggeredMethod
    {
        public static void ExecuteOn_SendingRequest_Through_CreateGetUserByNameHttpRequest(XComponent.SwaggerPetstore.UserObject.GetUserByNameOperation getUserByNameOperation, XComponent.SwaggerPetstore.UserObject.GetUserByNameOperation getUserByNameOperation_PublicMember, object object_InternalMember, Context context, ICreateGetUserByNameHttpRequestGetUserByNameOperationOnSendingRequestGetUserByNameOperationSenderInterface sender)
        {
            XComponent.Shared.XCClone.Clone(getUserByNameOperation, getUserByNameOperation_PublicMember);

            var task = TriggeredMethodContext.Instance.ServiceClient.GetUserByNameWithHttpMessagesAsync(getUserByNameOperation_PublicMember.Event.username);
            task.ContinueWith((Task<Microsoft.Rest.HttpOperationResponse<User>> httpTask) =>
            {
                try
                {
                    getUserByNameOperation_PublicMember.Message = httpTask.Result.Response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    getUserByNameOperation_PublicMember.HasErrors = !httpTask.Result.Response.IsSuccessStatusCode;
                    getUserByNameOperation_PublicMember.OperationResult = httpTask.Result.Body;
                    if (getUserByNameOperation_PublicMember.HasErrors)
                    {
                        sender.ReceiveError_GetUserByNameOperation(context, new ErrorResponse());
                    }
                    else
                    {
                        sender.ReceiveSuccess_GetUserByNameOperation(context, new SuccessResponse());
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

                    getUserByNameOperation_PublicMember.HasErrors = true;
                    sender.ReceiveError_GetUserByNameOperation(context, new ErrorResponse());
                }
            });

            // Go to "RequestSent" state..
            sender.SendRequest_GetUserByNameOperation(context, new XComponent.Common.Event.DefaultEvent());

            // Send the http request..

        }
    }
}