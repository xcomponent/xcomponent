using System;
using System.Collections.Generic;
using XComponent.Common.Helper;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.Referential.Common.StateHashCodeCalculator.Referential
{
    public class ReferentialStateHashCodeCalculator : IStateHashCodeCalculator<XComponent.Referential.UserObject.InstrumentSnapshot, Object>
    {
        public ISet<int> Calculate(XComponent.Referential.UserObject.InstrumentSnapshot publicMember, Object internalMember)
        {
            var hashcodes = new HashSet<int>();

            hashcodes.Add(0);
            return hashcodes;
        }
    }
}
