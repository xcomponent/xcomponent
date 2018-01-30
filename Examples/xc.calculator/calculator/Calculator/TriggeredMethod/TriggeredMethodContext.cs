using System;
using XComponent.Calculator.Common;
using XComponent.Calculator.Common.Senders;
using XComponent.Runtime.Shared.TriggeredMethods;
using XComponent.Runtime.Shared.Manager;
using XComponent.Common.Logger;
using XComponent.Functions.Core;

namespace XComponent.Calculator.TriggeredMethod
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
