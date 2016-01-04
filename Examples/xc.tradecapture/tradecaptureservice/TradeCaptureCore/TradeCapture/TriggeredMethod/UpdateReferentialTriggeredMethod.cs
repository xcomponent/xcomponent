
using XComponent.Common.ApiContext;
using XComponent.TradeCapture.Common.Senders;
using XComponent.Referential.UserObject;

namespace XComponent.TradeCapture.TriggeredMethod
{

	public static class UpdateReferentialTriggeredMethod
	{
		public static void ExecuteOn_UpdateReferential_Through_UpdateReferential(XComponent.Referential.UserObject.Instrument instrument_TriggeringEvent, XComponent.Referential.UserObject.Instrument instrument_PublicMember, object object_InternalMember, Context context, IUpdateReferentialInstrumentOnUpdateReferentialUpdateReferentialSenderInterface sender)
		{
			instrument_PublicMember.Name = instrument_TriggeringEvent.Name;
		}
	}
}
