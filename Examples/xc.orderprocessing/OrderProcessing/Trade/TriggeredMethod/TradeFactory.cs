using System.Threading;

namespace XComponent.Trade.TriggeredMethod
{
    public static class TradeFactory
    {
        private const int MarketPrice = 100;
        private static int currentId;

        public static Trade.UserObject.Trade CreateNewTrade(int orderId, double quantity, string assetName)
        {
            return new Trade.UserObject.Trade()
            {
                Id = GenerateTradeId(),
                OrderId = orderId,
                Price = 100.0,
                Quantity = quantity,
                AssetName = assetName
            };
        }

        private static int GenerateTradeId()
        {
            return Interlocked.Increment(ref currentId);
        }

    }
}