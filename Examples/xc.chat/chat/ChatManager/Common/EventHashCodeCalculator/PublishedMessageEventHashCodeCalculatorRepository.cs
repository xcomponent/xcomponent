using System.Collections.Generic;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.ChatManager.Common.EventHashCodeCalculator
{
	public class PublishedMessageEventHashCodeCalculatorRepository : IEventHashCodeCalculatorRepository
	{
		Dictionary<int, IEventHashCodeCalculator> _calculators;

		public PublishedMessageEventHashCodeCalculatorRepository()
		{
			_calculators = new Dictionary<int, IEventHashCodeCalculator>();
		}

		public Dictionary<int, IEventHashCodeCalculator> GetEventHashCodeCalculators()
		{
			return _calculators;
		}
	}
}