using System.Collections.Generic;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.Authentication.Common.EventHashCodeCalculator
{
	public class LoginStatusEventHashCodeCalculatorRepository : IEventHashCodeCalculatorRepository
	{
		Dictionary<int, IEventHashCodeCalculator> _calculators;

		public LoginStatusEventHashCodeCalculatorRepository()
		{
			_calculators = new Dictionary<int, IEventHashCodeCalculator>();
			_calculators.Add(8, new XComponent.Authentication.Common.EventHashCodeCalculator.LoginStatus.LoginErrorEventHashCodeCalculator());
			_calculators.Add(9, new XComponent.Authentication.Common.EventHashCodeCalculator.LoginStatus.LoginSuccessEventHashCodeCalculator());
		}

		public Dictionary<int, IEventHashCodeCalculator> GetEventHashCodeCalculators()
		{
			return _calculators;
		}
	}
}