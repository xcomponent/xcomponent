using System;
using System.Collections.Generic;
using XComponent.Common.Helper;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.SwaggerPetstore.Common.StateHashCodeCalculator.FindPetsByStatusOperation
{
    public class SendingRequestStateHashCodeCalculator : IStateHashCodeCalculator<XComponent.SwaggerPetstore.UserObject.FindPetsByStatusOperation, Object>
    {
        public ISet<int> Calculate(XComponent.SwaggerPetstore.UserObject.FindPetsByStatusOperation publicMember, Object internalMember)
        {
            var hashcodes = new HashSet<int>();

            hashcodes.Add(0);
            return hashcodes;
        }
    }
}
