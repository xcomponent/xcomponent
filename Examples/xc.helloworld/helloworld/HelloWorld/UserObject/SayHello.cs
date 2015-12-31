namespace XComponent.HelloWorld.UserObject
{
    
    
    // ICloneable interface can be implemented to override clone behaviour of XComponent
    // IDisposable interface can be implemented to dispose public/internal members when the state machine is in a final state
    // If ToString() can be overridden. XCSpy uses it to display state machine instances
    [System.Serializable()]
    public class SayHello
    {
        
        private string name;
        
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
    }
}
