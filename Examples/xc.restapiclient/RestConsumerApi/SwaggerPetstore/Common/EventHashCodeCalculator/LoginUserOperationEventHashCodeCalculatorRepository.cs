using System.Collections.Generic;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.SwaggerPetstore.Common.EventHashCodeCalculator
{
	public class LoginUserOperationEventHashCodeCalculatorRepository : IEventHashCodeCalculatorRepository
	{
		Dictionary<int, IEventHashCodeCalculator> _calculators;

		public LoginUserOperationEventHashCodeCalculatorRepository()
		{
			_calculators = new Dictionary<int, IEventHashCodeCalculator>();
			_calculators.Add(6, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.LoginUserOperation.DefaultEventEventHashCodeCalculator());
			_calculators.Add(22, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.LoginUserOperation.ErrorResponseEventHashCodeCalculator());
			_calculators.Add(48, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.LoginUserOperation.SuccessResponseEventHashCodeCalculator());
		}

		public Dictionary<int, IEventHashCodeCalculator> GetEventHashCodeCalculators()
		{
			return _calculators;
		}
	}
}