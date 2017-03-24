using System;
using System.Collections.Generic;
using XComponent.Common.Helper;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.Authentication.Common.StateHashCodeCalculator.HeartBeat
{
    public class UpStateHashCodeCalculator : IStateHashCodeCalculator<XComponent.Authentication.UserObject.AuthenticationHeartBeat, Object>
    {
        public ISet<int> Calculate(XComponent.Authentication.UserObject.AuthenticationHeartBeat publicMember, Object internalMember)
        {
            var hashcodes = new HashSet<int>();

            hashcodes.Add(0);
            return hashcodes;
        }
    }
}
