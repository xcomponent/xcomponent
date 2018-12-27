using System;
using XComponent.Common.ApiContext;
using XComponent.Common.Timeouts;
using XComponent.Order.Common;
using XComponent.Order.Common.Senders;
using XComponent.Order.UserObject;
using XComponent.Shared;

namespace XComponent.Order.TriggeredMethod
{
    using System;
    using XComponent.Common.ApiContext;
    using XComponent.Common.Timeouts;
    using XComponent.Order.Common.Senders;
    using XComponent.Order.Common;


    public static class OrderTriggeredMethod
    {
        private static int currentOrderId;

        public static void ExecuteOn_Pending_Through_CreateOrder(XComponent.Order.UserObject.OrderInput orderInput, XComponent.Order.UserObject.Order order, object object_InternalMember, RuntimeContext context, ICreateOrderOrderInputOnPendingOrderSenderInterface sender)
        {
            order.Id = System.Threading.Interlocked.Increment(ref currentOrderId);
            order.Quantity = orderInput.Quantity;
            order.AssetName = orderInput.AssetName;
            order.CreationDate = DateTime.Now;
            sender.PublishOrderCreation(context, new XComponent.Order.UserObject.OrderCreation
            {
                OrderId = order.Id,
                AssetName = order.AssetName,
                Quantity = order.Quantity
            });

        }
        public static void ExecuteOn_Executed_Through_Execute(XComponent.Order.UserObject.ExecutionInput executionInput, XComponent.Order.UserObject.Order order, object object_InternalMember, RuntimeContext context, IExecuteExecutionInputOnExecutedOrderSenderInterface sender)
        {
            double quantityToExecute = executionInput.Quantity;

            order.ExecutedQuantity += quantityToExecute;
            order.ExecutionDate = DateTime.Now;

            sender.PublishOrderFilled(context, new OrderExecution
            {
                OrderId = order.Id,
                AssetName = order.AssetName,
                Quantity = quantityToExecute,
                RemainingQuantity = 0,
                Price = executionInput.Price
            });
        }
        public static void ExecuteOn_PartiallyExecuted_Through_PartiallyExecute(XComponent.Order.UserObject.ExecutionInput executionInput, XComponent.Order.UserObject.Order order, object object_InternalMember, RuntimeContext context, IPartiallyExecuteExecutionInputOnPartiallyExecutedOrderSenderInterface sender)
        {
            double quantityToExecute = executionInput.Quantity;

            if (quantityToExecute > order.RemainingQuantity)
            {
                throw new Exception(string.Format("[Order {0}]: This is not a valid partial execution. Requested quantity {1} was bigger than the remaining quantity {2}", order.Id, quantityToExecute, order.RemainingQuantity));
            }

            order.ExecutedQuantity += quantityToExecute;

            sender.PublishOrderPartiallyFilled(context, new OrderExecution
            {
                OrderId = order.Id,
                Quantity = quantityToExecute,
                RemainingQuantity = order.RemainingQuantity,
                Price = executionInput.Price
            });
        }

    }
}