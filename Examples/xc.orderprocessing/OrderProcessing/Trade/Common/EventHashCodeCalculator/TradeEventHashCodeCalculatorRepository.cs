using System.Collections.Generic;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.Trade.Common.EventHashCodeCalculator
{
	public class TradeEventHashCodeCalculatorRepository : IEventHashCodeCalculatorRepository
	{
		Dictionary<int, IEventHashCodeCalculator> _calculators;

		public TradeEventHashCodeCalculatorRepository()
		{
			_calculators = new Dictionary<int, IEventHashCodeCalculator>();
			_calculators.Add(14, new XComponent.Trade.Common.EventHashCodeCalculator.Trade.TradeExecutionEventHashCodeCalculator());
		}

		public Dictionary<int, IEventHashCodeCalculator> GetEventHashCodeCalculators()
		{
			return _calculators;
		}
	}
}