using System;
using System.Collections.Generic;
using XComponent.Common.Helper;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.Order.Common.StateHashCodeCalculator.Order
{
    public class ExecutedStateHashCodeCalculator : IStateHashCodeCalculator<XComponent.Order.UserObject.Order, Object>
    {
        public ISet<int> Calculate(XComponent.Order.UserObject.Order publicMember, Object internalMember)
        {
            var hashcodes = new HashSet<int>();

            hashcodes.Add(0);
            return hashcodes;
        }
    }
}
