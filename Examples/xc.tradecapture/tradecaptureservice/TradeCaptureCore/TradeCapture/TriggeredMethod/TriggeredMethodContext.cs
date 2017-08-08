namespace XComponent.TradeCapture.TriggeredMethod
{
    using System;
    using XComponent.TradeCapture.Common;
    using XComponent.TradeCapture.Common.Senders;
    using XComponent.Runtime.Shared.TriggeredMethods;
    using XComponent.Runtime.Shared.Manager;
    using XComponent.Common.Logger;
    
    
    public partial class TriggeredMethodContext : ICustomTriggeredMethodContext
    {

        public void OnComponentInitialized()
        {
        }

        public void UnHanledException(XComponent.Runtime.StateMachine.Exceptions.TriggeredMethodException exception)
        {
        }
    }
}
