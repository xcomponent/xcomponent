using System;
using System.Collections.Generic;
using XComponent.Common.Helper;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.SwaggerPetstore.Common.StateHashCodeCalculator.CreateUsersWithArrayInputOperation
{
    public class RequestSentStateHashCodeCalculator : IStateHashCodeCalculator<XComponent.SwaggerPetstore.UserObject.CreateUsersWithArrayInputOperation, Object>
    {
        public ISet<int> Calculate(XComponent.SwaggerPetstore.UserObject.CreateUsersWithArrayInputOperation publicMember, Object internalMember)
        {
            var hashcodes = new HashSet<int>();

            hashcodes.Add(0);
            return hashcodes;
        }
    }
}
