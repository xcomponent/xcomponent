using System;
using System.Collections.Generic;
using XComponent.Common.Helper;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.SlackProxy.Common.StateHashCodeCalculator.PublishMessage
{
    public class ErrorStateHashCodeCalculator : IStateHashCodeCalculator<XComponent.SlackProxy.UserObject.PublishMessage, Object>
    {
        public ISet<int> Calculate(XComponent.SlackProxy.UserObject.PublishMessage publicMember, Object internalMember)
        {
            var hashcodes = new HashSet<int>();
            return hashcodes;
        }
    }
}
