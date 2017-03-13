using System.Collections.Generic;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.Referential.Common.EventHashCodeCalculator
{
	public class ReferentialEventHashCodeCalculatorRepository : IEventHashCodeCalculatorRepository
	{
		Dictionary<int, IEventHashCodeCalculator> _calculators;

		public ReferentialEventHashCodeCalculatorRepository()
		{
			_calculators = new Dictionary<int, IEventHashCodeCalculator>();
			_calculators.Add(6, new XComponent.Referential.Common.EventHashCodeCalculator.Referential.DefaultEventEventHashCodeCalculator());
			_calculators.Add(8, new XComponent.Referential.Common.EventHashCodeCalculator.Referential.GetSnapshotEventHashCodeCalculator());
			_calculators.Add(9, new XComponent.Referential.Common.EventHashCodeCalculator.Referential.InstrumentEventHashCodeCalculator());
		}

		public Dictionary<int, IEventHashCodeCalculator> GetEventHashCodeCalculators()
		{
			return _calculators;
		}
	}
}