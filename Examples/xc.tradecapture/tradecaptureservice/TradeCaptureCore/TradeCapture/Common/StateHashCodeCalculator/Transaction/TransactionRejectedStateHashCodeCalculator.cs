using System;
using System.Collections.Generic;
using XComponent.Common.Helper;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.TradeCapture.Common.StateHashCodeCalculator.Transaction
{
    public class TransactionRejectedStateHashCodeCalculator : IStateHashCodeCalculator<XComponent.TradeCapture.UserObject.Transaction, Object>
    {
        public ISet<int> Calculate(XComponent.TradeCapture.UserObject.Transaction publicMember, Object internalMember)
        {
            var hashcodes = new HashSet<int>();
            return hashcodes;
        }
    }
}
