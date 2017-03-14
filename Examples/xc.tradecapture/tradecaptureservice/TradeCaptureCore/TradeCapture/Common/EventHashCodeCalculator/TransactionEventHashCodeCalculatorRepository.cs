using System.Collections.Generic;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.TradeCapture.Common.EventHashCodeCalculator
{
	public class TransactionEventHashCodeCalculatorRepository : IEventHashCodeCalculatorRepository
	{
		Dictionary<int, IEventHashCodeCalculator> _calculators;

		public TransactionEventHashCodeCalculatorRepository()
		{
			_calculators = new Dictionary<int, IEventHashCodeCalculator>();
			_calculators.Add(6, new XComponent.TradeCapture.Common.EventHashCodeCalculator.Transaction.DefaultEventEventHashCodeCalculator());
			_calculators.Add(8, new XComponent.TradeCapture.Common.EventHashCodeCalculator.Transaction.GetSnapshotEventHashCodeCalculator());
			_calculators.Add(9, new XComponent.TradeCapture.Common.EventHashCodeCalculator.Transaction.InstrumentEventHashCodeCalculator());
			_calculators.Add(10, new XComponent.TradeCapture.Common.EventHashCodeCalculator.Transaction.InstrumentSnapshotEventHashCodeCalculator());
			_calculators.Add(11, new XComponent.TradeCapture.Common.EventHashCodeCalculator.Transaction.AcceptEventHashCodeCalculator());
			_calculators.Add(12, new XComponent.TradeCapture.Common.EventHashCodeCalculator.Transaction.ErrorEventHashCodeCalculator());
			_calculators.Add(13, new XComponent.TradeCapture.Common.EventHashCodeCalculator.Transaction.InitEventHashCodeCalculator());
			_calculators.Add(14, new XComponent.TradeCapture.Common.EventHashCodeCalculator.Transaction.RejectEventHashCodeCalculator());
			_calculators.Add(16, new XComponent.TradeCapture.Common.EventHashCodeCalculator.Transaction.UpdateAndRetryEventHashCodeCalculator());
		}

		public Dictionary<int, IEventHashCodeCalculator> GetEventHashCodeCalculators()
		{
			return _calculators;
		}
	}
}