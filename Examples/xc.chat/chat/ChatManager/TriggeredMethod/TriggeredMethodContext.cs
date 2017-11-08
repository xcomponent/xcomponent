using System;
using XComponent.ChatManager.Common;
using XComponent.ChatManager.Common.Senders;
using XComponent.Runtime.Shared.TriggeredMethods;
using XComponent.Runtime.Shared.Manager;
using XComponent.Common.Logger;

namespace XComponent.ChatManager.TriggeredMethod
{
    public partial class TriggeredMethodContext : ICustomTriggeredMethodContext
    {
        
        public void OnComponentInitialized()
        {
        }
        
        public void UnHanledException(XComponent.Runtime.StateMachine.Exceptions.TriggeredMethodException exception)
        {
        }
    }
    
    public partial interface ICustomTriggeredMethodContext
    {
    }
}
