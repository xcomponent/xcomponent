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
    public static class CreateUsersWithArrayInputOperationTriggeredMethod
    {
        public static void ExecuteOn_SendingRequest_Through_CreateCreateUsersWithArrayInputHttpRequest(XComponent.SwaggerPetstore.UserObject.CreateUsersWithArrayInputOperation createUsersWithArrayInputOperation, XComponent.SwaggerPetstore.UserObject.CreateUsersWithArrayInputOperation createUsersWithArrayInputOperation_PublicMember, object object_InternalMember, Context context, ICreateCreateUsersWithArrayInputHttpRequestCreateUsersWithArrayInputOperationOnSendingRequestCreateUsersWithArrayInputOperationSenderInterface sender)
        {
            XComponent.Shared.XCClone.Clone(createUsersWithArrayInputOperation, createUsersWithArrayInputOperation_PublicMember);

            var task = TriggeredMethodContext.Instance.ServiceClient.CreateUsersWithArrayInputWithHttpMessagesAsync(createUsersWithArrayInputOperation_PublicMember.Event.body);
            task.ContinueWith((Task<Microsoft.Rest.HttpOperationResponse> httpTask) =>
            {
                try
                {
                    createUsersWithArrayInputOperation_PublicMember.Message = httpTask.Result.Response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    createUsersWithArrayInputOperation_PublicMember.HasErrors = !httpTask.Result.Response.IsSuccessStatusCode;
                    if (createUsersWithArrayInputOperation_PublicMember.HasErrors)
                    {
                        sender.ReceiveError_CreateUsersWithArrayInputOperation(context, new ErrorResponse());
                    }
                    else
                    {
                        sender.ReceiveSuccess_CreateUsersWithArrayInputOperation(context, new SuccessResponse());
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

                    createUsersWithArrayInputOperation_PublicMember.HasErrors = true;
                    sender.ReceiveError_CreateUsersWithArrayInputOperation(context, new ErrorResponse());
                }
            });

            // Go to "RequestSent" state..
            sender.SendRequest_CreateUsersWithArrayInputOperation(context, new XComponent.Common.Event.DefaultEvent());

            // Send the http request..

        }
    }
}