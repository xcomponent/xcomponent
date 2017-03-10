using System;
using XComponent.Common.ApiContext;
using XComponent.Common.Timeouts;
using XComponent.SwaggerPetstore.Common;
using XComponent.SwaggerPetstore.Common.Senders;

namespace XComponent.SwaggerPetstore.TriggeredMethod
{
    using XComponent.SwaggerPetstore.UserObject.Models;
    using XComponent.SwaggerPetstore.UserObject;
    using XComponent.SwaggerPetstore.TriggeredMethod.ServiceClient;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System;
    using XComponent.Common.ApiContext;
    using XComponent.Common.Timeouts;
    using XComponent.SwaggerPetstore.Common.Senders;
    using XComponent.SwaggerPetstore.Common;


    public static class GetPetByIdOperationTriggeredMethod
    {

        /// <summary>
        /// Executing triggeredMethod ExecuteOn_SendingRequest_Through_CreateGetPetByIdHttpRequest
        /// </summary>
        public static void ExecuteOn_SendingRequest_Through_CreateGetPetByIdHttpRequest(XComponent.SwaggerPetstore.UserObject.GetPetByIdOperation getPetByIdOperation_TriggeringEvent, XComponent.SwaggerPetstore.UserObject.GetPetByIdOperation getPetByIdOperation_PublicMember, object object_InternalMember, Context context, ICreateGetPetByIdHttpRequestGetPetByIdOperationOnSendingRequestGetPetByIdOperationSenderInterface sender)
        {
            XComponent.Common.Clone.XCClone.Clone(getPetByIdOperation_TriggeringEvent, getPetByIdOperation_PublicMember);

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
            task.GetAwaiter().GetResult();
            // Uncomment the following line if you want to copy getPetByIdOperation_TriggeringEvent properties values into getPetByIdOperation_PublicMember
            //XComponent.Common.Clone.XCClone.Clone(getPetByIdOperation_TriggeringEvent,getPetByIdOperation_PublicMember);
            //

        }
    }
}