using System;
using System.Collections.Generic;
using XComponent.Common.Helper;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.ChatManager.Common.StateHashCodeCalculator.PublishedMessage
{
    public class PublishedStateHashCodeCalculator : IStateHashCodeCalculator<XComponent.ChatManager.UserObject.PublishedMessage, Object>
    {
        public ISet<int> Calculate(XComponent.ChatManager.UserObject.PublishedMessage publicMember, Object internalMember)
        {
            var hashcodes = new HashSet<int>();
            return hashcodes;
        }
    }
}
