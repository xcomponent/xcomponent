using System;
using System.Collections.Generic;
using XComponent.Common.Helper;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.Order.Common.StateHashCodeCalculator.CreationFacade
{
    public class CreatedStateHashCodeCalculator : IStateHashCodeCalculator<XComponent.Order.UserObject.OrderCreation, Object>
    {
        public ISet<int> Calculate(XComponent.Order.UserObject.OrderCreation publicMember, Object internalMember)
        {
            var hashcodes = new HashSet<int>();
            return hashcodes;
        }
    }
}
