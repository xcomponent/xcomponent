using XComponent.TradeCapture.UserObject;

namespace XComponent.TradeCapture.TriggeredMethod
{
    internal class Validator
    {
        public bool Validate(Transaction transaction)
        {
            return !string.IsNullOrEmpty(transaction.Instrument);
        }
    }
}