using System.Collections.Generic;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.Authentication.Common.EventHashCodeCalculator
{
	public class AuthenticationEventHashCodeCalculatorRepository : IEventHashCodeCalculatorRepository
	{
		Dictionary<int, IEventHashCodeCalculator> _calculators;

		public AuthenticationEventHashCodeCalculatorRepository()
		{
			_calculators = new Dictionary<int, IEventHashCodeCalculator>();
			_calculators.Add(4, new XComponent.Authentication.Common.EventHashCodeCalculator.Authentication.CheckLoginEventHashCodeCalculator());
			_calculators.Add(5, new XComponent.Authentication.Common.EventHashCodeCalculator.Authentication.CreateHeartBeatEventHashCodeCalculator());
			_calculators.Add(6, new XComponent.Authentication.Common.EventHashCodeCalculator.Authentication.InitializationErrorEventHashCodeCalculator());
			_calculators.Add(7, new XComponent.Authentication.Common.EventHashCodeCalculator.Authentication.InitializationSuccessEventHashCodeCalculator());
			_calculators.Add(18, new XComponent.Authentication.Common.EventHashCodeCalculator.Authentication.DefaultEventEventHashCodeCalculator());
		}

		public Dictionary<int, IEventHashCodeCalculator> GetEventHashCodeCalculators()
		{
			return _calculators;
		}
	}
}