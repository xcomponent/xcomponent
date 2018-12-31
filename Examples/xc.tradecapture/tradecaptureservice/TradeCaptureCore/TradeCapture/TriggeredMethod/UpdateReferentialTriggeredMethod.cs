using System;
using XComponent.Common.ApiContext;
using XComponent.Common.Timeouts;
using XComponent.Referential.UserObject;
using XComponent.Shared;
using XComponent.TradeCapture.Common;
using XComponent.TradeCapture.Common.Senders;

namespace XComponent.TradeCapture.TriggeredMethod
{
    public static class UpdateReferentialTriggeredMethod
    {
        public static void ExecuteOn_UpdateReferential_Through_UpdateReferential(XComponent.Referential.UserObject.Instrument instrument_TriggeringEvent, XComponent.Referential.UserObject.Instrument instrument_PublicMember, object object_InternalMember, RuntimeContext context, IUpdateReferentialInstrumentOnUpdateReferentialUpdateReferentialSenderInterface sender)
        {
            instrument_PublicMember.Name = instrument_TriggeringEvent.Name;
        }
    }
}