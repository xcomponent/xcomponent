using System.Collections.Generic;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.HelloWorld.Common.EventHashCodeCalculator
{
	public class HelloResponseEventHashCodeCalculatorRepository : IEventHashCodeCalculatorRepository
	{
		Dictionary<int, IEventHashCodeCalculator> _calculators;

		public HelloResponseEventHashCodeCalculatorRepository()
		{
			_calculators = new Dictionary<int, IEventHashCodeCalculator>();
		}

		public Dictionary<int, IEventHashCodeCalculator> GetEventHashCodeCalculators()
		{
			return _calculators;
		}
	}
}