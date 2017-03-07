using System;
using System.Collections.Generic;
using XComponent.Common.Helper;
using XComponent.Engine.Execution.HashCode;
using XComponent.Logger.Loggers;

namespace XComponent.Authentication.Common.EventHashCodeCalculator.Authentication
{
    public class InitializationErrorEventHashCodeCalculator : IEventHashCodeCalculator
    {
		private XComponentLogger _logger = new XComponentLogger();

        public IEnumerable<int> Calculate(object rawEvent)
        {
			var typedEvent = rawEvent as XComponent.Authentication.UserObject.InitializationError;
			if(typedEvent == null)
			{
				_logger.Error(string.Format("{0}EventHashCodeCalculator should be called with event {1} instead of {2}. This may be due to a generation problem.", "InitializationError", "XComponent.Authentication.UserObject.InitializationError", rawEvent != null ? rawEvent.GetType().ToString() : string.Empty));
				yield break;
			}

            yield return 0;
        }
    }
}
