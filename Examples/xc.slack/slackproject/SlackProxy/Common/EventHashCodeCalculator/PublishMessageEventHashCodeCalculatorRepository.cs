using System.Collections.Generic;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.SlackProxy.Common.EventHashCodeCalculator
{
	public class PublishMessageEventHashCodeCalculatorRepository : IEventHashCodeCalculatorRepository
	{
		Dictionary<int, IEventHashCodeCalculator> _calculators;

		public PublishMessageEventHashCodeCalculatorRepository()
		{
			_calculators = new Dictionary<int, IEventHashCodeCalculator>();
			_calculators.Add(8, new XComponent.SlackProxy.Common.EventHashCodeCalculator.PublishMessage.ErrorEventHashCodeCalculator());
			_calculators.Add(11, new XComponent.SlackProxy.Common.EventHashCodeCalculator.PublishMessage.SuccessEventHashCodeCalculator());
		}

		public Dictionary<int, IEventHashCodeCalculator> GetEventHashCodeCalculators()
		{
			return _calculators;
		}
	}
}