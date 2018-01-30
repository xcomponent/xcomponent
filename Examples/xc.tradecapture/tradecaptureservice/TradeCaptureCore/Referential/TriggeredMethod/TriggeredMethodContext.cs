namespace XComponent.Referential.TriggeredMethod
{
    using System;
    using XComponent.Referential.Common;
    using XComponent.Referential.Common.Senders;
    using XComponent.Runtime.Shared.TriggeredMethods;
    using XComponent.Runtime.Shared.Manager;
    using XComponent.Common.Logger;
    
    
    public partial class TriggeredMethodContext : ICustomTriggeredMethodContext
    {
        public void UnHanledException(XComponent.Runtime.StateMachine.Exceptions.TriggeredMethodException exception)
        {
        }


        public void OnComponentInitialized()
        {
  
        }
    }
}
