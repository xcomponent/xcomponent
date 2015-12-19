namespace XComponent.Trade.TriggeredMethod
{
	using System;
	using XComponent.Common.ApiContext;
	using XComponent.Common.Timeouts;
	using XComponent.Trade.Common.Senders;
	using XComponent.Trade.Common;


	public static class OrderPartialFillProxyTriggeredMethod
	{

		/// <summary>
		/// Executing triggeredMethod ExecuteOn_Up_Through_ProcessOrderPartialFill
		/// </summary>
		public static void ExecuteOn_Up_Through_ProcessOrderPartialFill(XComponent.Order.UserObject.OrderExecution orderExecution_TriggeringEvent, XComponent.Order.UserObject.OrderExecution orderExecution_PublicMember, object object_InternalMember, Context context, IProcessOrderPartialFillOrderExecutionOnUpOrderPartialFillProxySenderInterface sender)
		{
			XComponent.Common.Clone.XCClone.Clone(orderExecution_TriggeringEvent, orderExecution_PublicMember);
		}
	}
}
