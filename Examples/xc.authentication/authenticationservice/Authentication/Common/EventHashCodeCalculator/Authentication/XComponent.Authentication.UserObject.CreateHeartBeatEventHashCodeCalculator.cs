using System;
using System.Collections.Generic;
using XComponent.Common.Helper;
using XComponent.Engine.Execution.HashCode;
using XComponent.Logger.Loggers;

namespace XComponent.Authentication.Common.EventHashCodeCalculator.Authentication
{
    public class CreateHeartBeatEventHashCodeCalculator : IEventHashCodeCalculator
    {
		private XComponentLogger _logger = new XComponentLogger();

        public IEnumerable<int> Calculate(object rawEvent)
        {
			var typedEvent = rawEvent as XComponent.Authentication.UserObject.CreateHeartBeat;
			if(typedEvent == null)
			{
				_logger.Error(string.Format("{0}EventHashCodeCalculator should be called with event {1} instead of {2}. This may be due to a generation problem.", "CreateHeartBeat", "XComponent.Authentication.UserObject.CreateHeartBeat", rawEvent != null ? rawEvent.GetType().ToString() : string.Empty));
				yield break;
			}

            yield return 0;
        }
    }
}
