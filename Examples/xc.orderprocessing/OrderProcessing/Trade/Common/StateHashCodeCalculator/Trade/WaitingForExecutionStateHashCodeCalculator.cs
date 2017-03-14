using System;
using System.Collections.Generic;
using XComponent.Common.Helper;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.Trade.Common.StateHashCodeCalculator.Trade
{
    public class WaitingForExecutionStateHashCodeCalculator : IStateHashCodeCalculator<XComponent.Trade.UserObject.Trade, Object>
    {
        public ISet<int> Calculate(XComponent.Trade.UserObject.Trade publicMember, Object internalMember)
        {
            var hashcodes = new HashSet<int>();
            var hashCodeForPropertyOrderIdOfPublicMember = publicMember.OrderId != null ? HashcodeHelper.GetXcHashCode(publicMember.OrderId) : 0;

            hashcodes.Add( hashCodeForPropertyOrderIdOfPublicMember);
            return hashcodes;
        }
    }
}
