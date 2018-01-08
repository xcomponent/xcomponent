using System;
using System.Collections.Generic;
using XComponent.Common.Helper;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.SwaggerPetstore.Common.StateHashCodeCalculator.GetPetByIdOperation
{
    public class SendingRequestStateHashCodeCalculator : IStateHashCodeCalculator<XComponent.SwaggerPetstore.UserObject.GetPetByIdOperation, Object>
    {
        public ISet<int> Calculate(XComponent.SwaggerPetstore.UserObject.GetPetByIdOperation publicMember, Object internalMember)
        {
            var hashcodes = new HashSet<int>();

            hashcodes.Add(0);
            return hashcodes;
        }
    }
}
