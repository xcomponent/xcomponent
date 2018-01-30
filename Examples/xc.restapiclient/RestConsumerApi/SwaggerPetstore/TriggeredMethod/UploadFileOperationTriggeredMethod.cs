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
    public static class UploadFileOperationTriggeredMethod
    {
        public static void ExecuteOn_SendingRequest_Through_CreateUploadFileHttpRequest(XComponent.SwaggerPetstore.UserObject.UploadFileOperation uploadFileOperation, XComponent.SwaggerPetstore.UserObject.UploadFileOperation uploadFileOperation_PublicMember, object object_InternalMember, Context context, ICreateUploadFileHttpRequestUploadFileOperationOnSendingRequestUploadFileOperationSenderInterface sender)
        {
            XComponent.Shared.XCClone.Clone(uploadFileOperation, uploadFileOperation_PublicMember);

            var task = TriggeredMethodContext.Instance.ServiceClient.UploadFileWithHttpMessagesAsync(uploadFileOperation_PublicMember.Event.petId, uploadFileOperation_PublicMember.Event.additionalMetadata, uploadFileOperation_PublicMember.Event.file);
            task.ContinueWith((Task<Microsoft.Rest.HttpOperationResponse<ApiResponse>> httpTask) =>
            {
                try
                {
                    uploadFileOperation_PublicMember.Message = httpTask.Result.Response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    uploadFileOperation_PublicMember.HasErrors = !httpTask.Result.Response.IsSuccessStatusCode;
                    uploadFileOperation_PublicMember.OperationResult = httpTask.Result.Body;
                    if (uploadFileOperation_PublicMember.HasErrors)
                    {
                        sender.ReceiveError_UploadFileOperation(context, new ErrorResponse());
                    }
                    else
                    {
                        sender.ReceiveSuccess_UploadFileOperation(context, new SuccessResponse());
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

                    uploadFileOperation_PublicMember.HasErrors = true;
                    sender.ReceiveError_UploadFileOperation(context, new ErrorResponse());
                }
            });

            // Go to "RequestSent" state..
            sender.SendRequest_UploadFileOperation(context, new XComponent.Common.Event.DefaultEvent());

            // Send the http request..

        }
    }
}