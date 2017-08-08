using System;
using XComponent.Common.ApiContext;
using XComponent.Common.Timeouts;
using XComponent.Referential.UserObject;
using XComponent.Shared;
using XComponent.TradeCapture.Common;
using XComponent.TradeCapture.Common.Senders;
using XComponent.TradeCapture.UserObject;

namespace XComponent.TradeCapture.TriggeredMethod
{
    public static class TransactionTriggeredMethod
    {
        private static int count = 0;

        private static void DoMapping(XComponent.Referential.UserObject.InstrumentSnapshot triggeringEvent, XComponent.TradeCapture.UserObject.Transaction publicMember, Context context, dynamic sender)
        {
            if (triggeringEvent.Instruments.Contains(publicMember.Instrument))
            {
                Mapper mapper = new Mapper();
                publicMember.Instrument = mapper.GetValue(publicMember.Instrument, publicMember.ExecutionDate);
                sender.Accepted(context, new XComponent.TradeCapture.UserObject.Accept());
            }
            else
            {
                sender.Error(context, new Error());
            }
        }


        public static void ExecuteOn_Mapping_Through_InitMapping(XComponent.TradeCapture.UserObject.Init init, XComponent.TradeCapture.UserObject.Transaction transaction, object object_InternalMember, Context context, IInitMappingInitOnMappingTransactionSenderInterface sender)
        {
            sender.GetInstrumentSnapshot(context, new GetSnapshot());
        }


        public static void ExecuteOn_Validation_Through_UpdateAndRetry(XComponent.TradeCapture.UserObject.UpdateAndRetry updateAndRetry, XComponent.TradeCapture.UserObject.Transaction transaction, object object_InternalMember, Context context, IUpdateAndRetryUpdateAndRetryOnValidationTransactionSenderInterface sender)
        {

        }
        public static void ExecuteOn_TransactionRejected_Through_TimeOut(XComponent.Common.Event.DefaultEvent defaultEvent, XComponent.TradeCapture.UserObject.Transaction transaction, object object_InternalMember, Context context, ITimeOutDefaultEventOnTransactionRejectedTransactionSenderInterface sender)
        {

        }
        public static void ExecuteOn_ErrorOnMapping_Through_Error(XComponent.TradeCapture.UserObject.Error error, XComponent.TradeCapture.UserObject.Transaction transaction, object object_InternalMember, Context context, IErrorErrorOnErrorOnMappingTransactionSenderInterface sender)
        {
        }
        public static void ExecuteOn_TransactionAccepted_Through_Accepted(XComponent.TradeCapture.UserObject.Accept accept, XComponent.TradeCapture.UserObject.Transaction transaction, object object_InternalMember, Context context, IAcceptedAcceptOnTransactionAcceptedTransactionSenderInterface sender)
        {
        }
        public static void ExecuteOn_Validation_Through_NewTransaction(XComponent.TradeCapture.UserObject.Transaction transaction_TriggeringEvent, XComponent.TradeCapture.UserObject.Transaction transaction_PublicMember, object object_InternalMember, Context context, INewTransactionTransactionOnValidationTransactionSenderInterface sender)
        {
            transaction_TriggeringEvent.Id = count++;
            Validator validator = new Validator();
            if (validator.Validate(transaction_TriggeringEvent))
            {
                sender.InitMapping(context, new Init());
            }
            else
            {
                sender.ValidationError(context, new Error());
            }

            XComponent.Shared.XCClone.Clone(transaction_TriggeringEvent, transaction_PublicMember);

        }
        public static void ExecuteOn_TransactionRejected_Through_Reject(XComponent.TradeCapture.UserObject.Reject reject, XComponent.TradeCapture.UserObject.Transaction transaction, object object_InternalMember, Context context, IRejectRejectOnTransactionRejectedTransactionSenderInterface sender)
        {

        }
        public static void ExecuteOn_Mapping_Through_ReferentialNotification(XComponent.Referential.UserObject.InstrumentSnapshot instrumentSnapshot, XComponent.TradeCapture.UserObject.Transaction transaction, object object_InternalMember, Context context, IReferentialNotificationInstrumentSnapshotOnMappingTransactionSenderInterface sender)
        {
            DoMapping(instrumentSnapshot, transaction, context, sender);
        }
    }
}