using System.Collections.Generic;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.SwaggerPetstore.Common.EventHashCodeCalculator
{
	public class CreateUsersWithArrayInputOperationEventHashCodeCalculatorRepository : IEventHashCodeCalculatorRepository
	{
		Dictionary<int, IEventHashCodeCalculator> _calculators;

		public CreateUsersWithArrayInputOperationEventHashCodeCalculatorRepository()
		{
			_calculators = new Dictionary<int, IEventHashCodeCalculator>();
			_calculators.Add(6, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.CreateUsersWithArrayInputOperation.DefaultEventEventHashCodeCalculator());
			_calculators.Add(22, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.CreateUsersWithArrayInputOperation.ErrorResponseEventHashCodeCalculator());
			_calculators.Add(48, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.CreateUsersWithArrayInputOperation.SuccessResponseEventHashCodeCalculator());
		}

		public Dictionary<int, IEventHashCodeCalculator> GetEventHashCodeCalculators()
		{
			return _calculators;
		}
	}
}