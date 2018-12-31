using System;
using XComponent.Common.ApiContext;
using XComponent.Common.Timeouts;
using XComponent.Order.Common;
using XComponent.Order.Common.Senders;
using XComponent.Shared;

namespace XComponent.Order.TriggeredMethod
{
    using System;
    using XComponent.Common.ApiContext;
    using XComponent.Common.Timeouts;
    using XComponent.Order.Common.Senders;
    using XComponent.Order.Common;


    public static class ExecutionFacadeTriggeredMethod
    {

        /// <summary>
        /// Executing triggeredMethod ExecuteOn_Filled_Through_PublishOrderFilled
        /// </summary>
        public static void ExecuteOn_Filled_Through_PublishOrderFilled(XComponent.Order.UserObject.OrderExecution orderExecution_TriggeringEvent, XComponent.Order.UserObject.OrderExecution orderExecution_PublicMember, object object_InternalMember, RuntimeContext context, IPublishOrderFilledOrderExecutionOnFilledExecutionFacadeSenderInterface sender)
        {
            XComponent.Shared.XCClone.Clone(orderExecution_TriggeringEvent, orderExecution_PublicMember);
        }
    }
}