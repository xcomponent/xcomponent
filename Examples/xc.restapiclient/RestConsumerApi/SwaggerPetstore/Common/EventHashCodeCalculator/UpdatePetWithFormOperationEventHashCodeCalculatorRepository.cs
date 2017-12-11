using System.Collections.Generic;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.SwaggerPetstore.Common.EventHashCodeCalculator
{
	public class UpdatePetWithFormOperationEventHashCodeCalculatorRepository : IEventHashCodeCalculatorRepository
	{
		Dictionary<int, IEventHashCodeCalculator> _calculators;

		public UpdatePetWithFormOperationEventHashCodeCalculatorRepository()
		{
			_calculators = new Dictionary<int, IEventHashCodeCalculator>();
			_calculators.Add(6, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.UpdatePetWithFormOperation.DefaultEventEventHashCodeCalculator());
			_calculators.Add(22, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.UpdatePetWithFormOperation.ErrorResponseEventHashCodeCalculator());
			_calculators.Add(48, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.UpdatePetWithFormOperation.SuccessResponseEventHashCodeCalculator());
		}

		public Dictionary<int, IEventHashCodeCalculator> GetEventHashCodeCalculators()
		{
			return _calculators;
		}
	}
}