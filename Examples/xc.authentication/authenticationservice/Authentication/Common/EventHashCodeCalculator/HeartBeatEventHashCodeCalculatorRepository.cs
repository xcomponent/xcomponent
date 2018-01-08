using System.Collections.Generic;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.Authentication.Common.EventHashCodeCalculator
{
	public class HeartBeatEventHashCodeCalculatorRepository : IEventHashCodeCalculatorRepository
	{
		Dictionary<int, IEventHashCodeCalculator> _calculators;

		public HeartBeatEventHashCodeCalculatorRepository()
		{
			_calculators = new Dictionary<int, IEventHashCodeCalculator>();
			_calculators.Add(18, new XComponent.Authentication.Common.EventHashCodeCalculator.HeartBeat.DefaultEventEventHashCodeCalculator());
		}

		public Dictionary<int, IEventHashCodeCalculator> GetEventHashCodeCalculators()
		{
			return _calculators;
		}
	}
}