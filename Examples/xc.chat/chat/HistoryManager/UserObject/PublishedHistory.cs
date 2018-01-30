using System;
using System.Collections.Generic;
using XComponent.ChatManager.UserObject;

namespace XComponent.HistoryManager.UserObject
{
    // ICloneable interface can be implemented to override clone behaviour of XComponent
    // IDisposable interface can be implemented to dispose public/internal members when the state machine is in a final state
    // ToString() can be overridden. XCSpy uses it to display state machine instances
    [System.Serializable()]
    public class PublishedHistory
    {
        public PublishedHistory()
        {
            Messages = new List<PublishedMessage>();
        }

        public List<PublishedMessage> Messages { get; set; }

    }
}