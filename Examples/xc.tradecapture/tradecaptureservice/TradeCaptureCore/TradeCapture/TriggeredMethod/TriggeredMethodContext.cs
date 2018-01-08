namespace XComponent.TradeCapture.TriggeredMethod
{
    using System;
    using XComponent.TradeCapture.Common;
    using XComponent.TradeCapture.Common.Senders;
    using XComponent.Common.TriggeredMethod;
    using XComponent.Common.Manager;
    using XComponent.Common.Logger;
    
    
    public partial class TriggeredMethodContext : ICustomTriggeredMethodContext
    {

        public void OnComponentInitialized()
        {
        }

        public void UnHanledException(TriggeredMethodException exception)
        {
        }
    }
}
