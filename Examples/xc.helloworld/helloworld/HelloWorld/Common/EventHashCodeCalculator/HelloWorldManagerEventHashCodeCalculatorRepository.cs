using System.Collections.Generic;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.HelloWorld.Common.EventHashCodeCalculator
{
	public class HelloWorldManagerEventHashCodeCalculatorRepository : IEventHashCodeCalculatorRepository
	{
		Dictionary<int, IEventHashCodeCalculator> _calculators;

		public HelloWorldManagerEventHashCodeCalculatorRepository()
		{
			_calculators = new Dictionary<int, IEventHashCodeCalculator>();
			_calculators.Add(9, new XComponent.HelloWorld.Common.EventHashCodeCalculator.HelloWorldManager.SayHelloEventHashCodeCalculator());
		}

		public Dictionary<int, IEventHashCodeCalculator> GetEventHashCodeCalculators()
		{
			return _calculators;
		}
	}
}