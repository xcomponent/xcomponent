namespace XComponent.Order.UserObject
{
    
    
    // ICloneable interface can be implemented to override clone behaviour of XComponent
    // IDisposable interface can be implemented to dispose public/internal members when the state machine is in a final state
    // ToString() can be overridden. XCSpy uses it to display state machine instances
    [System.Serializable()]
    public class OrderExecution
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
        
        private double remainingQuantity;
        
        public double RemainingQuantity
        {
            get
            {
                return this.remainingQuantity;
            }
            set
            {
                this.remainingQuantity = value;
            }
        }
        
        private double price;
        
        public double Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = value;
            }
        }
    }
}
