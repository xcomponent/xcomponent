using System.Collections.Generic;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.SwaggerPetstore.Common.EventHashCodeCalculator
{
	public class SwaggerPetstoreEventHashCodeCalculatorRepository : IEventHashCodeCalculatorRepository
	{
		Dictionary<int, IEventHashCodeCalculator> _calculators;

		public SwaggerPetstoreEventHashCodeCalculatorRepository()
		{
			_calculators = new Dictionary<int, IEventHashCodeCalculator>();
			_calculators.Add(6, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.SwaggerPetstore.DefaultEventEventHashCodeCalculator());
			_calculators.Add(8, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.SwaggerPetstore.AddPetEventHashCodeCalculator());
			_calculators.Add(9, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.SwaggerPetstore.AddPetOperationEventHashCodeCalculator());
			_calculators.Add(11, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.SwaggerPetstore.GetPetByIdEventHashCodeCalculator());
			_calculators.Add(12, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.SwaggerPetstore.GetPetByIdOperationEventHashCodeCalculator());
		}

		public Dictionary<int, IEventHashCodeCalculator> GetEventHashCodeCalculators()
		{
			return _calculators;
		}
	}
}