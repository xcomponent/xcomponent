namespace XComponent.Order.TriggeredMethod
{
	using System;
	using XComponent.Common.ApiContext;
	using XComponent.Order.Common;


	public class OrderUserSpecificRules
	{

		/// <summary>
		/// Check custom key CheckUserSpecificRule_Executed_From_Pending_Through_Execute
		/// </summary>
		public static bool CheckUserSpecificRule_Executed_From_Pending_Through_Execute(XComponent.Order.UserObject.ExecutionInput executionInput, XComponent.Order.UserObject.Order order, object object_InternalMember)
		{
			return executionInput.Quantity == order.RemainingQuantity;
		}

		/// <summary>
		/// Check custom key CheckUserSpecificRule_PartiallyExecuted_From_Pending_Through_PartiallyExecute
		/// </summary>
		public static bool CheckUserSpecificRule_PartiallyExecuted_From_Pending_Through_PartiallyExecute(XComponent.Order.UserObject.ExecutionInput executionInput, XComponent.Order.UserObject.Order order, object object_InternalMember)
		{
			return executionInput.Quantity != order.RemainingQuantity;
		}

		/// <summary>
		/// Check custom key CheckUserSpecificRule_Executed_From_PartiallyExecuted_Through_Execute
		/// </summary>
		public static bool CheckUserSpecificRule_Executed_From_PartiallyExecuted_Through_Execute(XComponent.Order.UserObject.ExecutionInput executionInput, XComponent.Order.UserObject.Order order, object object_InternalMember)
		{
			return executionInput.Quantity == order.RemainingQuantity;
		}

		/// <summary>
		/// Check custom key CheckUserSpecificRule_PartiallyExecuted_From_PartiallyExecuted_Through_PartiallyExecute
		/// </summary>
		public static bool CheckUserSpecificRule_PartiallyExecuted_From_PartiallyExecuted_Through_PartiallyExecute(XComponent.Order.UserObject.ExecutionInput executionInput, XComponent.Order.UserObject.Order order, object object_InternalMember)
		{
			return executionInput.Quantity != order.RemainingQuantity;
		}
	}
}
