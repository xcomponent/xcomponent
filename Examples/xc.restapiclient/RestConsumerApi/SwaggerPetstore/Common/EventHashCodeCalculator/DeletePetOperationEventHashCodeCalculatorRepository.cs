using System.Collections.Generic;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.SwaggerPetstore.Common.EventHashCodeCalculator
{
	public class DeletePetOperationEventHashCodeCalculatorRepository : IEventHashCodeCalculatorRepository
	{
		Dictionary<int, IEventHashCodeCalculator> _calculators;

		public DeletePetOperationEventHashCodeCalculatorRepository()
		{
			_calculators = new Dictionary<int, IEventHashCodeCalculator>();
			_calculators.Add(6, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.DeletePetOperation.DefaultEventEventHashCodeCalculator());
			_calculators.Add(22, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.DeletePetOperation.ErrorResponseEventHashCodeCalculator());
			_calculators.Add(48, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.DeletePetOperation.SuccessResponseEventHashCodeCalculator());
		}

		public Dictionary<int, IEventHashCodeCalculator> GetEventHashCodeCalculators()
		{
			return _calculators;
		}
	}
}