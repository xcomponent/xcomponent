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
    public static class CreateUsersWithListInputOperationTriggeredMethod
    {
        public static void ExecuteOn_SendingRequest_Through_CreateCreateUsersWithListInputHttpRequest(XComponent.SwaggerPetstore.UserObject.CreateUsersWithListInputOperation createUsersWithListInputOperation, XComponent.SwaggerPetstore.UserObject.CreateUsersWithListInputOperation createUsersWithListInputOperation_PublicMember, object object_InternalMember, Context context, ICreateCreateUsersWithListInputHttpRequestCreateUsersWithListInputOperationOnSendingRequestCreateUsersWithListInputOperationSenderInterface sender)
        {
            XComponent.Shared.XCClone.Clone(createUsersWithListInputOperation, createUsersWithListInputOperation_PublicMember);

            var task = TriggeredMethodContext.Instance.ServiceClient.CreateUsersWithListInputWithHttpMessagesAsync(createUsersWithListInputOperation_PublicMember.Event.body);
            task.ContinueWith((Task<Microsoft.Rest.HttpOperationResponse> httpTask) =>
            {
                try
                {
                    createUsersWithListInputOperation_PublicMember.Message = httpTask.Result.Response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    createUsersWithListInputOperation_PublicMember.HasErrors = !httpTask.Result.Response.IsSuccessStatusCode;
                    if (createUsersWithListInputOperation_PublicMember.HasErrors)
                    {
                        sender.ReceiveError_CreateUsersWithListInputOperation(context, new ErrorResponse());
                    }
                    else
                    {
                        sender.ReceiveSuccess_CreateUsersWithListInputOperation(context, new SuccessResponse());
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

                    createUsersWithListInputOperation_PublicMember.HasErrors = true;
                    sender.ReceiveError_CreateUsersWithListInputOperation(context, new ErrorResponse());
                }
            });

            // Go to "RequestSent" state..
            sender.SendRequest_CreateUsersWithListInputOperation(context, new XComponent.Common.Event.DefaultEvent());

            // Send the http request..

        }
    }
}