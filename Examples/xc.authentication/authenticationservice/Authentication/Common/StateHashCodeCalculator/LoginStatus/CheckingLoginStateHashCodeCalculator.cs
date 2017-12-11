using System;
using System.Collections.Generic;
using XComponent.Common.Helper;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.Authentication.Common.StateHashCodeCalculator.LoginStatus
{
    public class CheckingLoginStateHashCodeCalculator : IStateHashCodeCalculator<XComponent.Authentication.UserObject.CheckLogin, Object>
    {
        public ISet<int> Calculate(XComponent.Authentication.UserObject.CheckLogin publicMember, Object internalMember)
        {
            var hashcodes = new HashSet<int>();

            hashcodes.Add(0);
            return hashcodes;
        }
    }
}
