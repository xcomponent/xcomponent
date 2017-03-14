using System.Collections.Generic;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.TradeCapture.Common.EventHashCodeCalculator
{
	public class XCTradeProcessorEventHashCodeCalculatorRepository : IEventHashCodeCalculatorRepository
	{
		Dictionary<int, IEventHashCodeCalculator> _calculators;

		public XCTradeProcessorEventHashCodeCalculatorRepository()
		{
			_calculators = new Dictionary<int, IEventHashCodeCalculator>();
			_calculators.Add(15, new XComponent.TradeCapture.Common.EventHashCodeCalculator.XCTradeProcessor.TransactionEventHashCodeCalculator());
		}

		public Dictionary<int, IEventHashCodeCalculator> GetEventHashCodeCalculators()
		{
			return _calculators;
		}
	}
}