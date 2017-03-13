using System.Collections.Generic;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.SlackProxy.Common.EventHashCodeCalculator
{
	public class SlackProxyEventHashCodeCalculatorRepository : IEventHashCodeCalculatorRepository
	{
		Dictionary<int, IEventHashCodeCalculator> _calculators;

		public SlackProxyEventHashCodeCalculatorRepository()
		{
			_calculators = new Dictionary<int, IEventHashCodeCalculator>();
			_calculators.Add(6, new XComponent.SlackProxy.Common.EventHashCodeCalculator.SlackProxy.DefaultEventEventHashCodeCalculator());
			_calculators.Add(10, new XComponent.SlackProxy.Common.EventHashCodeCalculator.SlackProxy.SendMessageEventHashCodeCalculator());
		}

		public Dictionary<int, IEventHashCodeCalculator> GetEventHashCodeCalculators()
		{
			return _calculators;
		}
	}
}