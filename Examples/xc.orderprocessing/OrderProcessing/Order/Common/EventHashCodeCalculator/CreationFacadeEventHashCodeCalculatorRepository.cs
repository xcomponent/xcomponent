using System.Collections.Generic;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.Order.Common.EventHashCodeCalculator
{
	public class CreationFacadeEventHashCodeCalculatorRepository : IEventHashCodeCalculatorRepository
	{
		Dictionary<int, IEventHashCodeCalculator> _calculators;

		public CreationFacadeEventHashCodeCalculatorRepository()
		{
			_calculators = new Dictionary<int, IEventHashCodeCalculator>();
		}

		public Dictionary<int, IEventHashCodeCalculator> GetEventHashCodeCalculators()
		{
			return _calculators;
		}
	}
}