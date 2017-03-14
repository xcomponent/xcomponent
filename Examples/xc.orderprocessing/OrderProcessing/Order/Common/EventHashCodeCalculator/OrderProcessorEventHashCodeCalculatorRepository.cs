using System.Collections.Generic;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.Order.Common.EventHashCodeCalculator
{
	public class OrderProcessorEventHashCodeCalculatorRepository : IEventHashCodeCalculatorRepository
	{
		Dictionary<int, IEventHashCodeCalculator> _calculators;

		public OrderProcessorEventHashCodeCalculatorRepository()
		{
			_calculators = new Dictionary<int, IEventHashCodeCalculator>();
			_calculators.Add(6, new XComponent.Order.Common.EventHashCodeCalculator.OrderProcessor.DefaultEventEventHashCodeCalculator());
			_calculators.Add(12, new XComponent.Order.Common.EventHashCodeCalculator.OrderProcessor.OrderInputEventHashCodeCalculator());
		}

		public Dictionary<int, IEventHashCodeCalculator> GetEventHashCodeCalculators()
		{
			return _calculators;
		}
	}
}