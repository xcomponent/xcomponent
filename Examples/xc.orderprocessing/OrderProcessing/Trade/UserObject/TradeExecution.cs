using System;

namespace XComponent.Trade.UserObject
{
    [Serializable]
    public class TradeExecution
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