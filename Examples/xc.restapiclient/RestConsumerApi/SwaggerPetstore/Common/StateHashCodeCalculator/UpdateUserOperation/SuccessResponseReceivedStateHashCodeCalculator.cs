using System;
using System.Collections.Generic;
using XComponent.Common.Helper;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.SwaggerPetstore.Common.StateHashCodeCalculator.UpdateUserOperation
{
    public class SuccessResponseReceivedStateHashCodeCalculator : IStateHashCodeCalculator<XComponent.SwaggerPetstore.UserObject.UpdateUserOperation, Object>
    {
        public ISet<int> Calculate(XComponent.SwaggerPetstore.UserObject.UpdateUserOperation publicMember, Object internalMember)
        {
            var hashcodes = new HashSet<int>();
            return hashcodes;
        }
    }
}
