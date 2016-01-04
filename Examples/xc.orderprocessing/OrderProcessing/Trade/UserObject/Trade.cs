using System;

namespace XComponent.Trade.UserObject
{
    
    
    // ICloneable interface can be implemented to override clone behaviour of XComponent
    // IDisposable interface can be implemented to dispose public/internal members when the state machine is in a final state
    // ToString() can be overridden. XCSpy uses it to display state machine instances
    [System.Serializable()]
    public class Trade
    {
        
        private int id;
        
        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }
        
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
        
        private string state;
        
        public string State
        {
            get
            {
                return this.state;
            }
            set
            {
                this.state = value;
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

        private DateTime? executionDate;

        public DateTime? ExecutionDate
        {
            get { return executionDate; }
            set { executionDate = value; }
        }

    }
}
