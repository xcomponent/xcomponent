using System;
using System.Collections.Generic;
using XComponent.Common.Helper;
using XComponent.Engine.Execution.HashCode;
using XComponent.Logger.Loggers;

namespace XComponent.TradeCapture.Common.EventHashCodeCalculator.Transaction
{
    public class InstrumentEventHashCodeCalculator : IEventHashCodeCalculator
    {
		private XComponentLogger _logger = new XComponentLogger();

        public IEnumerable<int> Calculate(object rawEvent)
        {
			var typedEvent = rawEvent as XComponent.Referential.UserObject.Instrument;
			if(typedEvent == null)
			{
				_logger.Error(string.Format("{0}EventHashCodeCalculator should be called with event {1} instead of {2}. This may be due to a generation problem.", "Instrument", "XComponent.Referential.UserObject.Instrument", rawEvent != null ? rawEvent.GetType().ToString() : string.Empty));
				yield break;
			}

            yield return 0;
        }
    }
}
