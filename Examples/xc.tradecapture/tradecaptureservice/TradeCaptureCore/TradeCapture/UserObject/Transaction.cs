using System;

namespace XComponent.TradeCapture.UserObject
{
    [Serializable]
    public class Transaction
    {
        private string _currentState;
        public Transaction()
        {
            ExecutionDate = DateTime.Now;
        }
        public string Instrument { get; set; }
        public DateTime ExecutionDate { get; set; }
        public double Price { get; set; }
        public int Id { get; set; }

        public string CurrentState
        {
            get
            {
                return _currentState;
            }
            set
            {
                PreviousState = _currentState;
                _currentState = value;
            }
        }

        public string PreviousState { get; set; }
    }
}
