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


	public static class AddPetOperationTriggeredMethod
	{

		/// <summary>
		/// Executing triggeredMethod ExecuteOn_SendingRequest_Through_CreateAddPetHttpRequest
		/// </summary>
		public static void ExecuteOn_SendingRequest_Through_CreateAddPetHttpRequest(XComponent.SwaggerPetstore.UserObject.AddPetOperation addPetOperation_TriggeringEvent, XComponent.SwaggerPetstore.UserObject.AddPetOperation addPetOperation_PublicMember, object object_InternalMember, Context context, ICreateAddPetHttpRequestAddPetOperationOnSendingRequestAddPetOperationSenderInterface sender)
		{
			XComponent.Common.Clone.XCClone.Clone(addPetOperation_TriggeringEvent, addPetOperation_PublicMember);

			var task = TriggeredMethodContext.Instance.ServiceClient.AddPetWithHttpMessagesAsync(addPetOperation_PublicMember.Event.body);
			task.ContinueWith((Task<Microsoft.Rest.HttpOperationResponse> httpTask) =>
			{
				try {
					addPetOperation_PublicMember.Message = httpTask.Result.Response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
					addPetOperation_PublicMember.HasErrors = !httpTask.Result.Response.IsSuccessStatusCode;
					if (addPetOperation_PublicMember.HasErrors) {
						sender.ReceiveError_AddPetOperation(context, new ErrorResponse());
					} else {
						sender.ReceiveSuccess_AddPetOperation(context, new SuccessResponse());
					}
				} catch (AggregateException ae) {
					Exception innerexception = ae.InnerException;
					while (innerexception != null) {
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
			task.GetAwaiter().GetResult();
			// Uncomment the following line if you want to copy addPetOperation_TriggeringEvent properties values into addPetOperation_PublicMember
			//XComponent.Common.Clone.XCClone.Clone(addPetOperation_TriggeringEvent,addPetOperation_PublicMember);
			//

		}
	}
}
