using System;
using System.Collections.Generic;
using XComponent.Common.Helper;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.Order.Common.StateHashCodeCalculator.PartialExecutionFacade
{
    public class PartiallyFilledStateHashCodeCalculator : IStateHashCodeCalculator<XComponent.Order.UserObject.OrderExecution, Object>
    {
        public ISet<int> Calculate(XComponent.Order.UserObject.OrderExecution publicMember, Object internalMember)
        {
            var hashcodes = new HashSet<int>();
            return hashcodes;
        }
    }
}
