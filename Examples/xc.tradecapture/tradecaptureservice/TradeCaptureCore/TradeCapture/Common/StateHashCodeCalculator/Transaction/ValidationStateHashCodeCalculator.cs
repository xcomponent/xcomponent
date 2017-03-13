using System;
using System.Collections.Generic;
using XComponent.Common.Helper;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.TradeCapture.Common.StateHashCodeCalculator.Transaction
{
    public class ValidationStateHashCodeCalculator : IStateHashCodeCalculator<XComponent.TradeCapture.UserObject.Transaction, Object>
    {
        public ISet<int> Calculate(XComponent.TradeCapture.UserObject.Transaction publicMember, Object internalMember)
        {
            var hashcodes = new HashSet<int>();

            hashcodes.Add(0);
            return hashcodes;
        }
    }
}
