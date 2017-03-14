using System;
using System.Collections.Generic;
using XComponent.Common.Helper;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.Trade.Common.StateHashCodeCalculator.Trade
{
    public class ExecutedStateHashCodeCalculator : IStateHashCodeCalculator<XComponent.Trade.UserObject.Trade, Object>
    {
        public ISet<int> Calculate(XComponent.Trade.UserObject.Trade publicMember, Object internalMember)
        {
            var hashcodes = new HashSet<int>();
            return hashcodes;
        }
    }
}
