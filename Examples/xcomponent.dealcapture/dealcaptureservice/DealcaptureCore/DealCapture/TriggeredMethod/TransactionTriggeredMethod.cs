
using XComponent.Common.ApiContext;
using XComponent.DealCapture.Common.Senders;
using XComponent.DealCapture.UserObject;
using XComponent.Referential.UserObject;

namespace XComponent.DealCapture.TriggeredMethod
{

	public static class TransactionTriggeredMethod
	{
		private static int count = 0;

		private static void DoMapping(XComponent.Referential.UserObject.InstrumentSnapshot triggeringEvent, XComponent.DealCapture.UserObject.Transaction publicMember, Context context, dynamic sender)
		{
			if (triggeringEvent.Instruments.Contains(publicMember.Instrument)) {
				Mapper mapper = new Mapper();
				publicMember.Instrument = mapper.GetValue(publicMember.Instrument, publicMember.ExecutionDate);
				sender.Accepted(context, new XComponent.DealCapture.UserObject.Accept());
			} else {
				sender.Error(context, new Error());
			}
		}

		public static void ExecuteOn_ValidationError_Through_ValidationError(XComponent.DealCapture.UserObject.Error error, XComponent.DealCapture.UserObject.Transaction transaction, object object_InternalMember, Context context, IValidationErrorErrorOnValidationErrorTransactionSenderInterface sender)
		{
			transaction.FromTransition = XComponent.DealCapture.Common.TransitionEnum.ValidationError.ToString();
		}

		public static void ExecuteOn_Mapping_Through_InitMapping(XComponent.DealCapture.UserObject.Init init, XComponent.DealCapture.UserObject.Transaction transaction, object object_InternalMember, Context context, IInitMappingInitOnMappingTransactionSenderInterface sender)
		{
			sender.GetInstrumentSnapshot(context, new GetSnapshot());
		}

		public static void ExecuteOn_TransactionRejected_Through_Reject(XComponent.DealCapture.UserObject.Reject reject, XComponent.DealCapture.UserObject.Transaction transaction, object object_InternalMember, Context context, IRejectRejectOnTransactionRejectedTransactionSenderInterface sender)
		{
			transaction.FromTransition = XComponent.DealCapture.Common.TransitionEnum.Reject.ToString();
		}
		public static void ExecuteOn_Validation_Through_UpdateAndRetry(XComponent.DealCapture.UserObject.UpdateAndRetry updateAndRetry, XComponent.DealCapture.UserObject.Transaction transaction, object object_InternalMember, Context context, IUpdateAndRetryUpdateAndRetryOnValidationTransactionSenderInterface sender)
		{
			transaction.FromTransition = XComponent.DealCapture.Common.TransitionEnum.UpdateAndRetry.ToString();
		}
		public static void ExecuteOn_TransactionRejected_Through_TimeOut(XComponent.Common.Event.DefaultEvent defaultEvent, XComponent.DealCapture.UserObject.Transaction transaction, object object_InternalMember, Context context, ITimeOutDefaultEventOnTransactionRejectedTransactionSenderInterface sender)
		{
			transaction.FromTransition = XComponent.DealCapture.Common.TransitionEnum.TimeOut.ToString();
		}
		public static void ExecuteOn_ErrorOnMapping_Through_Error(XComponent.DealCapture.UserObject.Error error, XComponent.DealCapture.UserObject.Transaction transaction, object object_InternalMember, Context context, IErrorErrorOnErrorOnMappingTransactionSenderInterface sender)
		{
			transaction.FromTransition = XComponent.DealCapture.Common.TransitionEnum.Error.ToString();
		}
		public static void ExecuteOn_TransactionAccepted_Through_Accepted(XComponent.DealCapture.UserObject.Accept accept, XComponent.DealCapture.UserObject.Transaction transaction, object object_InternalMember, Context context, IAcceptedAcceptOnTransactionAcceptedTransactionSenderInterface sender)
		{
			transaction.FromTransition = XComponent.DealCapture.Common.TransitionEnum.Accepted.ToString();
		}
		public static void ExecuteOn_Mapping_Through_InstrumentSnapshot(XComponent.Referential.UserObject.InstrumentSnapshot instrumentSnapshot, XComponent.DealCapture.UserObject.Transaction transaction, object object_InternalMember, Context context, IInstrumentSnapshotInstrumentSnapshotOnMappingTransactionSenderInterface sender)
		{
			DoMapping(instrumentSnapshot, transaction, context, sender);
		}
		public static void ExecuteOn_Mapping_Through_ReferentialUpdated(XComponent.Referential.UserObject.InstrumentSnapshot instrumentSnapshot, XComponent.DealCapture.UserObject.Transaction transaction, object object_InternalMember, Context context, IReferentialUpdatedInstrumentSnapshotOnMappingTransactionSenderInterface sender)
		{
			DoMapping(instrumentSnapshot, transaction, context, sender);

			transaction.FromTransition = XComponent.DealCapture.Common.TransitionEnum.ReferentialUpdated.ToString();
		}
		public static void ExecuteOn_Validation_Through_NewTransaction(XComponent.DealCapture.UserObject.Transaction transaction_TriggeringEvent, XComponent.DealCapture.UserObject.Transaction transaction_PublicMember, object object_InternalMember, Context context, INewTransactionTransactionOnValidationTransactionSenderInterface sender)
		{
			transaction_TriggeringEvent.Id = count++;
			Validator validator = new Validator();
			if (validator.Validate(transaction_TriggeringEvent)) {
				sender.InitMapping(context, new Init());
			} else {
				sender.ValidationError(context, new Error());
			}

			XComponent.Common.Clone.XCClone.Clone(transaction_TriggeringEvent, transaction_PublicMember);

			transaction_PublicMember.FromTransition = XComponent.DealCapture.Common.TransitionEnum.NewTransaction.ToString();
		}
	}
}
