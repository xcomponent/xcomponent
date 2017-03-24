using System;
using System.Collections.Generic;
using XComponent.Common.Helper;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.SwaggerPetstore.Common.StateHashCodeCalculator.FindPetsByTagsOperation
{
    public class ErrorResponseReceivedStateHashCodeCalculator : IStateHashCodeCalculator<XComponent.SwaggerPetstore.UserObject.FindPetsByTagsOperation, Object>
    {
        public ISet<int> Calculate(XComponent.SwaggerPetstore.UserObject.FindPetsByTagsOperation publicMember, Object internalMember)
        {
            var hashcodes = new HashSet<int>();
            return hashcodes;
        }
    }
}
