using System.Collections.Generic;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.ChatManager.Common.EventHashCodeCalculator
{
	public class ChatroomEventHashCodeCalculatorRepository : IEventHashCodeCalculatorRepository
	{
		Dictionary<int, IEventHashCodeCalculator> _calculators;

		public ChatroomEventHashCodeCalculatorRepository()
		{
			_calculators = new Dictionary<int, IEventHashCodeCalculator>();
			_calculators.Add(1, new XComponent.ChatManager.Common.EventHashCodeCalculator.Chatroom.CloseRoomEventHashCodeCalculator());
			_calculators.Add(3, new XComponent.ChatManager.Common.EventHashCodeCalculator.Chatroom.PublishedMessageEventHashCodeCalculator());
			_calculators.Add(4, new XComponent.ChatManager.Common.EventHashCodeCalculator.Chatroom.SentMessageEventHashCodeCalculator());
		}

		public Dictionary<int, IEventHashCodeCalculator> GetEventHashCodeCalculators()
		{
			return _calculators;
		}
	}
}