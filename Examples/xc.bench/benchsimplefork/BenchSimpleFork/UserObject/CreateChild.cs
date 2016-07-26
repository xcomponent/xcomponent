namespace XComponent.BenchSimpleFork.UserObject
{
    
    
    // ICloneable interface can be implemented to override clone behaviour of XComponent
    // IDisposable interface can be implemented to dispose public/internal members when the state machine is in a final state
    // ToString() can be overridden. XCSpy uses it to display state machine instances
    [System.Serializable()]
    public class CreateChild
    {
        
        private bool isFirst;
        
        public bool IsFirst
        {
            get
            {
                return this.isFirst;
            }
            set
            {
                this.isFirst = value;
            }
        }
        
        private bool isLast;
        
        public bool IsLast
        {
            get
            {
                return this.isLast;
            }
            set
            {
                this.isLast = value;
            }
        }
    }
}
