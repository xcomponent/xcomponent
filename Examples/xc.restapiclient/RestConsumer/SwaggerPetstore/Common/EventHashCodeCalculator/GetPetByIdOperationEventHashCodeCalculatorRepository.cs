using System.Collections.Generic;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.SwaggerPetstore.Common.EventHashCodeCalculator
{
	public class GetPetByIdOperationEventHashCodeCalculatorRepository : IEventHashCodeCalculatorRepository
	{
		Dictionary<int, IEventHashCodeCalculator> _calculators;

		public GetPetByIdOperationEventHashCodeCalculatorRepository()
		{
			_calculators = new Dictionary<int, IEventHashCodeCalculator>();
			_calculators.Add(6, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.GetPetByIdOperation.DefaultEventEventHashCodeCalculator());
			_calculators.Add(10, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.GetPetByIdOperation.ErrorResponseEventHashCodeCalculator());
			_calculators.Add(19, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.GetPetByIdOperation.SuccessResponseEventHashCodeCalculator());
		}

		public Dictionary<int, IEventHashCodeCalculator> GetEventHashCodeCalculators()
		{
			return _calculators;
		}
	}
}