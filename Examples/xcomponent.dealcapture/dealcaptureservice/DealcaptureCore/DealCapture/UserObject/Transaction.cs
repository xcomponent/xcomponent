using System;

namespace XComponent.DealCapture.UserObject
{
    [Serializable]
    public class Transaction
    {
        public Transaction()
        {
            ExecutionDate = DateTime.Now;
        }
        public string Instrument { get; set; }
        public DateTime ExecutionDate { get; set; }
        public double Price { get; set; }
        public int Id { get; set; }

        public string FromTransition { get; set; }
    }
}
