using System.Collections.Generic;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.Order.Common.EventHashCodeCalculator
{
	public class OrderEventHashCodeCalculatorRepository : IEventHashCodeCalculatorRepository
	{
		Dictionary<int, IEventHashCodeCalculator> _calculators;

		public OrderEventHashCodeCalculatorRepository()
		{
			_calculators = new Dictionary<int, IEventHashCodeCalculator>();
			_calculators.Add(8, new XComponent.Order.Common.EventHashCodeCalculator.Order.ExecutionInputEventHashCodeCalculator());
			_calculators.Add(10, new XComponent.Order.Common.EventHashCodeCalculator.Order.OrderCreationEventHashCodeCalculator());
			_calculators.Add(11, new XComponent.Order.Common.EventHashCodeCalculator.Order.OrderExecutionEventHashCodeCalculator());
		}

		public Dictionary<int, IEventHashCodeCalculator> GetEventHashCodeCalculators()
		{
			return _calculators;
		}
	}
}