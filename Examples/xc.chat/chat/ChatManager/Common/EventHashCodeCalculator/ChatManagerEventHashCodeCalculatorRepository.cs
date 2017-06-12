using System.Collections.Generic;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.ChatManager.Common.EventHashCodeCalculator
{
	public class ChatManagerEventHashCodeCalculatorRepository : IEventHashCodeCalculatorRepository
	{
		Dictionary<int, IEventHashCodeCalculator> _calculators;

		public ChatManagerEventHashCodeCalculatorRepository()
		{
			_calculators = new Dictionary<int, IEventHashCodeCalculator>();
			_calculators.Add(2, new XComponent.ChatManager.Common.EventHashCodeCalculator.ChatManager.CreateChatroomEventHashCodeCalculator());
		}

		public Dictionary<int, IEventHashCodeCalculator> GetEventHashCodeCalculators()
		{
			return _calculators;
		}
	}
}