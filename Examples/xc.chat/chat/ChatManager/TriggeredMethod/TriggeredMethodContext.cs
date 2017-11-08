using System;
using XComponent.ChatManager.Common;
using XComponent.ChatManager.Common.Senders;
using XComponent.Common.TriggeredMethod;
using XComponent.Common.Manager;
using XComponent.Common.Logger;

namespace XComponent.ChatManager.TriggeredMethod
{
    public partial class TriggeredMethodContext : ICustomTriggeredMethodContext
    {
        
        public void OnComponentInitialized()
        {
        }
        
        public void UnHanledException(XComponent.Common.TriggeredMethod.TriggeredMethodException exception)
        {
        }
    }
    
    public partial interface ICustomTriggeredMethodContext
    {
    }
}
