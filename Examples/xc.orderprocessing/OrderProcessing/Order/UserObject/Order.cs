using System;

namespace XComponent.Order.UserObject
{
    
    
    // ICloneable interface can be implemented to override clone behaviour of XComponent
    // IDisposable interface can be implemented to dispose public/internal members when the state machine is in a final state
    // ToString() can be overridden. XCSpy uses it to display state machine instances
    [System.Serializable()]
    public class Order
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
        
        private double executedQuantity;
        
        public double ExecutedQuantity
        {
            get
            {
                return this.executedQuantity;
            }
            set
            {
                this.executedQuantity = value;
            }
        }

        public double RemainingQuantity
        {
            get { return Quantity - ExecutedQuantity; }
        }

        private DateTime creationDate;

        public DateTime CreationDate
        {
            get
            {
                return this.creationDate;
            }
            set
            {
                this.creationDate = value;
            }
        }

        private DateTime? executionDate;

        public DateTime? ExecutionDate
        {
            get
            {
                return this.executionDate;
            }
            set
            {
                this.executionDate = value;
            }
        }
    }
}
