using System;
using XComponent.Common.ApiContext;
using XComponent.Common.Timeouts;
using XComponent.Shared;
using XComponent.Trade.Common;
using XComponent.Trade.Common.Senders;
using XComponent.Trade.UserObject;

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
        /// <summary>
        /// Executing triggeredMethod ExecuteOn_Up_Through_ProcessOrderCreation
        /// </summary>
        public static void ExecuteOn_Up_Through_ProcessOrderCreation(XComponent.Order.UserObject.OrderCreation orderCreation, object object_PublicMember, object object_InternalMember, Context context, IProcessOrderCreationOrderCreationOnUpTradeProcessorSenderInterface sender)
        {
            sender.CreateTrade(context, TradeFactory.CreateNewTrade(orderCreation.OrderId, orderCreation.Quantity, orderCreation.AssetName));
        }

        public static void ExecuteOn_Up_Through_ProcessOrderExecution(XComponent.Order.UserObject.OrderExecution orderExecution, object object_PublicMember, object object_InternalMember, Context context, IProcessOrderExecutionOrderExecutionOnUpTradeProcessorSenderInterface sender)
        {
            // Execute the existing trade for a revised quantity
            var tradeExecution = new TradeExecution
            {
                AssetName = orderExecution.AssetName,
                OrderId = orderExecution.OrderId,
                Price = orderExecution.Price,
                Quantity = orderExecution.Quantity,
                RemainingQuantity = orderExecution.RemainingQuantity
            };
            sender.ExecuteTrade(context, tradeExecution);

            // Create a new trade for the remaining quantity
            if (orderExecution.RemainingQuantity > 0)
            {
                sender.CreateTrade(context, TradeFactory.CreateNewTrade(orderExecution.OrderId, orderExecution.RemainingQuantity, orderExecution.AssetName));
            }
        }

        public static void ExecuteOn_Up_Through_ExecuteTrade(XComponent.Trade.UserObject.TradeExecution tradeExecution, object object_PublicMember, object object_InternalMember, Context context, IExecuteTradeTradeExecutionOnUpTradeProcessorSenderInterface sender)
        {
            sender.SendEvent(StdEnum.Trade, tradeExecution);
        }

    }
}