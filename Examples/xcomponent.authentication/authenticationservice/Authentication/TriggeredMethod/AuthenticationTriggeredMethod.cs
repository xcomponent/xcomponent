using System.Linq;

namespace XComponent.Authentication.TriggeredMethod
{
	using System;
	using XComponent.Common.ApiContext;
	using XComponent.Common.Timeouts;
	using XComponent.Authentication.Common.Senders;
	using XComponent.Authentication.Common;


	public static class AuthenticationTriggeredMethod
	{

		/// <summary>
		/// Executing triggeredMethod ExecuteOn_Initializing_Through_Initialize
		/// </summary>
		public static void ExecuteOn_Initializing_Through_Initialize(XComponent.Common.Event.DefaultEvent defaultEvent, object object_PublicMember, object object_InternalMember, Context context, IInitializeDefaultEventOnInitializingAuthenticationSenderInterface sender)
		{
			if (!TriggeredMethodContext.Instance.Users.Any()) {
				sender.InitializationError(context);
			} else {
				sender.InitializationSuccess(context);
			}
		}

		/// <summary>
		/// Executing triggeredMethod ExecuteOn_Up_Through_InitializationSuccess
		/// </summary>
		public static void ExecuteOn_Up_Through_InitializationSuccess(XComponent.Authentication.UserObject.InitializationSuccess initializationSuccess, object object_PublicMember, object object_InternalMember, Context context, IInitializationSuccessInitializationSuccessOnUpAuthenticationSenderInterface sender)
		{
			sender.CreateHeartBeat(context);
		}
	}
}
