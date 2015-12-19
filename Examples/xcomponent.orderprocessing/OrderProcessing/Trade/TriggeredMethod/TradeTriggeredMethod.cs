namespace XComponent.Trade.TriggeredMethod
{
	using System;
	using XComponent.Common.ApiContext;
	using XComponent.Common.Timeouts;
	using XComponent.Trade.Common.Senders;
	using XComponent.Trade.Common;


	public static class TradeTriggeredMethod
	{

		/// <summary>
		/// Executing triggeredMethod ExecuteOn_WaitingForExecution_Through_CreateTrade
		/// </summary>
		public static void ExecuteOn_WaitingForExecution_Through_CreateTrade(XComponent.Trade.UserObject.Trade trade_TriggeringEvent, XComponent.Trade.UserObject.Trade trade_PublicMember, object object_InternalMember, Context context, ICreateTradeTradeOnWaitingForExecutionTradeSenderInterface sender)
		{
			XComponent.Common.Clone.XCClone.Clone(trade_TriggeringEvent, trade_PublicMember);
		}
		public static void ExecuteOn_Executed_Through_Execute(XComponent.Order.UserObject.OrderExecution orderExecution, XComponent.Trade.UserObject.Trade trade, object object_InternalMember, Context context, IExecuteOrderExecutionOnExecutedTradeSenderInterface sender)
		{
			trade.Quantity = orderExecution.Quantity;
			trade.Price = orderExecution.Price;
			trade.ExecutionDate = DateTime.Now;

			if (orderExecution.RemainingQuantity > 0) {
				sender.ProcessOrderPartialFill_Trade(context, orderExecution);
			}

		}
	}
}
