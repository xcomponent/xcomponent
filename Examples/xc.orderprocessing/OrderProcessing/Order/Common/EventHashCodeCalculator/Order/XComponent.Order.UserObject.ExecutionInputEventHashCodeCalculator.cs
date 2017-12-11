using System;
using System.Collections.Generic;
using XComponent.Common.Helper;
using XComponent.Engine.Execution.HashCode;
using XComponent.Logger.Loggers;

namespace XComponent.Order.Common.EventHashCodeCalculator.Order
{
    public class ExecutionInputEventHashCodeCalculator : IEventHashCodeCalculator
    {
		private XComponentLogger _logger = new XComponentLogger();

        public IEnumerable<int> Calculate(object rawEvent)
        {
			var typedEvent = rawEvent as XComponent.Order.UserObject.ExecutionInput;
			if(typedEvent == null)
			{
				_logger.Error(string.Format("{0}EventHashCodeCalculator should be called with event {1} instead of {2}. This may be due to a generation problem.", "ExecutionInput", "XComponent.Order.UserObject.ExecutionInput", rawEvent != null ? rawEvent.GetType().ToString() : string.Empty));
				yield break;
			}
            var hashCodeForPropertyOrderIdOfEvent = typedEvent.OrderId != null ? HashcodeHelper.GetXcHashCode(typedEvent.OrderId) : 0;

            yield return hashCodeForPropertyOrderIdOfEvent;
        }
    }
}
