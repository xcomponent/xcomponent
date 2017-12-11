using System.Collections.Generic;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.SwaggerPetstore.Common.EventHashCodeCalculator
{
	public class CreateUsersWithListInputOperationEventHashCodeCalculatorRepository : IEventHashCodeCalculatorRepository
	{
		Dictionary<int, IEventHashCodeCalculator> _calculators;

		public CreateUsersWithListInputOperationEventHashCodeCalculatorRepository()
		{
			_calculators = new Dictionary<int, IEventHashCodeCalculator>();
			_calculators.Add(6, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.CreateUsersWithListInputOperation.DefaultEventEventHashCodeCalculator());
			_calculators.Add(22, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.CreateUsersWithListInputOperation.ErrorResponseEventHashCodeCalculator());
			_calculators.Add(48, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.CreateUsersWithListInputOperation.SuccessResponseEventHashCodeCalculator());
		}

		public Dictionary<int, IEventHashCodeCalculator> GetEventHashCodeCalculators()
		{
			return _calculators;
		}
	}
}