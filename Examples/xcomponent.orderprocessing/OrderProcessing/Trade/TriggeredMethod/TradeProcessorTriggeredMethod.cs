namespace XComponent.Trade.TriggeredMethod
{
	using System;
	using XComponent.Common.ApiContext;
	using XComponent.Common.Timeouts;
	using XComponent.Trade.Common.Senders;
	using XComponent.Trade.Common;


	public static class TradeProcessorTriggeredMethod
	{

		/// <summary>
		/// Executing triggeredMethod ExecuteOn_Up_Through_ProcessOrderCreation
		/// </summary>
		public static void ExecuteOn_Up_Through_ProcessOrderCreation(XComponent.Order.UserObject.OrderCreation orderCreation, object object_PublicMember, object object_InternalMember, Context context, IProcessOrderCreationOrderCreationOnUpTradeProcessorSenderInterface sender)
		{
			sender.CreateTrade(context, TradeFactory.CreateNewTrade(orderCreation.OrderId, orderCreation.Quantity, orderCreation.AssetName));
		}
		public static void ExecuteOn_Up_Through_ProcessOrderPartialFill(XComponent.Order.UserObject.OrderExecution orderExecution, object object_PublicMember, object object_InternalMember, Context context, IProcessOrderPartialFillOrderExecutionOnUpTradeProcessorSenderInterface sender)
		{
			sender.CreateTrade(context, TradeFactory.CreateNewTrade(orderExecution.OrderId, orderExecution.RemainingQuantity, orderExecution.AssetName));
		}
	}
}
