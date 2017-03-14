using System;
using System.Collections.Generic;
using XComponent.Common.Helper;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.TradeCapture.Common.StateHashCodeCalculator.UpdateReferential
{
    public class UpdateReferentialStateHashCodeCalculator : IStateHashCodeCalculator<XComponent.Referential.UserObject.Instrument, Object>
    {
        public ISet<int> Calculate(XComponent.Referential.UserObject.Instrument publicMember, Object internalMember)
        {
            var hashcodes = new HashSet<int>();
            return hashcodes;
        }
    }
}
