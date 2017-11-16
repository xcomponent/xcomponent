using System;
using XComponent.HistoryManager.Common;
using XComponent.HistoryManager.Common.Senders;
using XComponent.Runtime.Shared.TriggeredMethods;
using XComponent.Runtime.Shared.Manager;
using XComponent.Common.Logger;

namespace XComponent.HistoryManager.TriggeredMethod
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
