using System.Collections.Generic;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.TradeCapture.Common.EventHashCodeCalculator
{
	public class UpdateReferentialEventHashCodeCalculatorRepository : IEventHashCodeCalculatorRepository
	{
		Dictionary<int, IEventHashCodeCalculator> _calculators;

		public UpdateReferentialEventHashCodeCalculatorRepository()
		{
			_calculators = new Dictionary<int, IEventHashCodeCalculator>();
		}

		public Dictionary<int, IEventHashCodeCalculator> GetEventHashCodeCalculators()
		{
			return _calculators;
		}
	}
}