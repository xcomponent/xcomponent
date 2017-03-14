using System;
using System.Collections.Generic;
using XComponent.Common.Helper;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.Order.Common.StateHashCodeCalculator.ExecutionFacade
{
    public class FilledStateHashCodeCalculator : IStateHashCodeCalculator<XComponent.Order.UserObject.OrderExecution, Object>
    {
        public ISet<int> Calculate(XComponent.Order.UserObject.OrderExecution publicMember, Object internalMember)
        {
            var hashcodes = new HashSet<int>();
            return hashcodes;
        }
    }
}
