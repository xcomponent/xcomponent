using System.Collections.Generic;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.Order.Common.EventHashCodeCalculator
{
	public class ExecutionFacadeEventHashCodeCalculatorRepository : IEventHashCodeCalculatorRepository
	{
		Dictionary<int, IEventHashCodeCalculator> _calculators;

		public ExecutionFacadeEventHashCodeCalculatorRepository()
		{
			_calculators = new Dictionary<int, IEventHashCodeCalculator>();
		}

		public Dictionary<int, IEventHashCodeCalculator> GetEventHashCodeCalculators()
		{
			return _calculators;
		}
	}
}