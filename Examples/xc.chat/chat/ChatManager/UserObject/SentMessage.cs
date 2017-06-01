using System;
using System.Collections.Generic;

namespace XComponent.ChatManager.UserObject
{
    // ICloneable interface can be implemented to override clone behaviour of XComponent
    // IDisposable interface can be implemented to dispose public/internal members when the state machine is in a final state
    // ToString() can be overridden. XCSpy uses it to display state machine instances
    [System.Serializable()]
    public class SentMessage
    {
        public string User { get; set; }
        public string Message { get; set; }
    }
}