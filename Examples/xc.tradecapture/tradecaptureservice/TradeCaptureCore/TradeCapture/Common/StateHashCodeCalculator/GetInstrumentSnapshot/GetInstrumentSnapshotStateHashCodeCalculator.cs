using System;
using System.Collections.Generic;
using XComponent.Common.Helper;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.TradeCapture.Common.StateHashCodeCalculator.GetInstrumentSnapshot
{
    public class GetInstrumentSnapshotStateHashCodeCalculator : IStateHashCodeCalculator<XComponent.Referential.UserObject.GetSnapshot, Object>
    {
        public ISet<int> Calculate(XComponent.Referential.UserObject.GetSnapshot publicMember, Object internalMember)
        {
            var hashcodes = new HashSet<int>();
            return hashcodes;
        }
    }
}
