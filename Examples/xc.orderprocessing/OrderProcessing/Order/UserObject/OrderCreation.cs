namespace XComponent.Order.UserObject
{
    
    
    // ICloneable interface can be implemented to override clone behaviour of XComponent
    // IDisposable interface can be implemented to dispose public/internal members when the state machine is in a final state
    // ToString() can be overridden. XCSpy uses it to display state machine instances
    [System.Serializable()]
    public class OrderCreation
    {
        
        private int orderId;
        
        public int OrderId
        {
            get
            {
                return this.orderId;
            }
            set
            {
                this.orderId = value;
            }
        }
        
        private double quantity;
        
        public double Quantity
        {
            get
            {
                return this.quantity;
            }
            set
            {
                this.quantity = value;
            }
        }
        
        private string assetName;
        
        public string AssetName
        {
            get
            {
                return this.assetName;
            }
            set
            {
                this.assetName = value;
            }
        }
    }
}
