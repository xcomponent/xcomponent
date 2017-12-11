using System;
using System.Collections.Generic;
using XComponent.Common.Helper;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.HelloWorld.Common.StateHashCodeCalculator.HelloResponse
{
    public class DoneStateHashCodeCalculator : IStateHashCodeCalculator<XComponent.HelloWorld.UserObject.HelloResponse, Object>
    {
        public ISet<int> Calculate(XComponent.HelloWorld.UserObject.HelloResponse publicMember, Object internalMember)
        {
            var hashcodes = new HashSet<int>();
            return hashcodes;
        }
    }
}
