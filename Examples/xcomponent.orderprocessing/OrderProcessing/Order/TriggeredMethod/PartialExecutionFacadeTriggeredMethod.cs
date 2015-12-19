namespace XComponent.Order.TriggeredMethod
{
	using System;
	using XComponent.Common.ApiContext;
	using XComponent.Common.Timeouts;
	using XComponent.Order.Common.Senders;
	using XComponent.Order.Common;


	public static class PartialExecutionFacadeTriggeredMethod
	{

		/// <summary>
		/// Executing triggeredMethod ExecuteOn_PartiallyFilled_Through_PublishOrderPartiallyFilled
		/// </summary>
		public static void ExecuteOn_PartiallyFilled_Through_PublishOrderPartiallyFilled(XComponent.Order.UserObject.OrderExecution orderExecution_TriggeringEvent, XComponent.Order.UserObject.OrderExecution orderExecution_PublicMember, object object_InternalMember, Context context, IPublishOrderPartiallyFilledOrderExecutionOnPartiallyFilledPartialExecutionFacadeSenderInterface sender)
		{
			XComponent.Common.Clone.XCClone.Clone(orderExecution_TriggeringEvent, orderExecution_PublicMember);
		}
	}
}
