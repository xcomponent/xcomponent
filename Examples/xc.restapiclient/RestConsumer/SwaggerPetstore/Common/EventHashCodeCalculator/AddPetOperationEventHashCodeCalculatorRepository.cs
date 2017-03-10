using System.Collections.Generic;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.SwaggerPetstore.Common.EventHashCodeCalculator
{
	public class AddPetOperationEventHashCodeCalculatorRepository : IEventHashCodeCalculatorRepository
	{
		Dictionary<int, IEventHashCodeCalculator> _calculators;

		public AddPetOperationEventHashCodeCalculatorRepository()
		{
			_calculators = new Dictionary<int, IEventHashCodeCalculator>();
			_calculators.Add(6, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.AddPetOperation.DefaultEventEventHashCodeCalculator());
			_calculators.Add(10, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.AddPetOperation.ErrorResponseEventHashCodeCalculator());
			_calculators.Add(19, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.AddPetOperation.SuccessResponseEventHashCodeCalculator());
		}

		public Dictionary<int, IEventHashCodeCalculator> GetEventHashCodeCalculators()
		{
			return _calculators;
		}
	}
}