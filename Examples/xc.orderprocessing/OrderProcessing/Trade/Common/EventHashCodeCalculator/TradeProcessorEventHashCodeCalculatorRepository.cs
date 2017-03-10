using System.Collections.Generic;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.Trade.Common.EventHashCodeCalculator
{
	public class TradeProcessorEventHashCodeCalculatorRepository : IEventHashCodeCalculatorRepository
	{
		Dictionary<int, IEventHashCodeCalculator> _calculators;

		public TradeProcessorEventHashCodeCalculatorRepository()
		{
			_calculators = new Dictionary<int, IEventHashCodeCalculator>();
			_calculators.Add(6, new XComponent.Trade.Common.EventHashCodeCalculator.TradeProcessor.DefaultEventEventHashCodeCalculator());
			_calculators.Add(10, new XComponent.Trade.Common.EventHashCodeCalculator.TradeProcessor.OrderCreationEventHashCodeCalculator());
			_calculators.Add(11, new XComponent.Trade.Common.EventHashCodeCalculator.TradeProcessor.OrderExecutionEventHashCodeCalculator());
			_calculators.Add(13, new XComponent.Trade.Common.EventHashCodeCalculator.TradeProcessor.TradeEventHashCodeCalculator());
			_calculators.Add(14, new XComponent.Trade.Common.EventHashCodeCalculator.TradeProcessor.TradeExecutionEventHashCodeCalculator());
		}

		public Dictionary<int, IEventHashCodeCalculator> GetEventHashCodeCalculators()
		{
			return _calculators;
		}
	}
}