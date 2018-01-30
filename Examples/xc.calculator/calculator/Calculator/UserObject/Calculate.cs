using System;
using System.Collections.Generic;

namespace XComponent.Calculator.UserObject
{
    // ICloneable interface can be implemented to override clone behaviour of XComponent
    // IDisposable interface can be implemented to dispose public/internal members when the state machine is in a final state
    // ToString() can be overridden. XCSpy uses it to display state machine instances
    [System.Serializable()]
    public class Calculate
    {
        public double Number1 { get; set; }

        public double Number2 { get; set; }

    }
}