using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using XComponent.DealCapture.BlotterApi;
using XComponent.DealCapture.BlotterApi.DealCapture;
using XComponent.DealCapture.UserObject;
using XComponent.Referential.UserObject;

namespace WpfApplication1
{
    public enum TransactionState
    {
        Accepted,
        Error,
        Rejected
    }

    class BlotterViewModel
    {
        public ObservableCollection<TransactionLine> Transactions { get; private set; }
        readonly private BlotterApi _blotterApi = new BlotterApi();

        public BlotterViewModel()
        {
            Transactions = new ObservableCollection<TransactionLine>();

            ClientApiHelper.Instance.Api.DealCapture_Component.Transaction_StateMachine.TransactionAccepted_State.InstanceUpdated += TransactionAccepted_State_InstanceUpdated;
            ClientApiHelper.Instance.Api.DealCapture_Component.Transaction_StateMachine.TransactionRejected_State.InstanceUpdated += TransactionRejected_State_InstanceUpdated;
            ClientApiHelper.Instance.Api.DealCapture_Component.Transaction_StateMachine.ErrorOnMapping_State.InstanceUpdated += ErrorOnMapping_State_InstanceUpdated;
            ClientApiHelper.Instance.Api.DealCapture_Component.Transaction_StateMachine.ValidationError_State.InstanceUpdated += ValidationError_State_InstanceUpdated;

            Task.Factory.StartNew(() =>
            {
               return  ClientApiHelper.Instance.Api.DealCapture_Component.Transaction_StateMachine.GetSnapshot();
            }).ContinueWith((t) =>
            {
                foreach (var transactionInstance in t.Result)
                {
                    switch (transactionInstance.StateCode)
                    {
                        case (int)Transaction_StateMachine.TransactionStateEnum.TransactionAccepted:
                            TransactionAccepted_State_InstanceUpdated(transactionInstance);
                            break;
                        case (int)Transaction_StateMachine.TransactionStateEnum.TransactionRejected:
                            TransactionRejected_State_InstanceUpdated(transactionInstance);
                            break;
                        case (int)Transaction_StateMachine.TransactionStateEnum.ErrorOnMapping:
                            ErrorOnMapping_State_InstanceUpdated(transactionInstance);
                            break;
                        case (int)Transaction_StateMachine.TransactionStateEnum.ValidationError:
                            ValidationError_State_InstanceUpdated(transactionInstance);
                            break;
                    }
                  
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());

        }

        void ErrorOnMapping_State_InstanceUpdated(TransactionInstance obj)
        {
            if (Application.Current.Dispatcher.Thread != Thread.CurrentThread)
            {
                Application.Current.Dispatcher.BeginInvoke(new Action<TransactionInstance>(ErrorOnMapping_State_InstanceUpdated), obj);
                return;
            }

            TransactionLine line = this.Transactions.FirstOrDefault(e => e.Transaction.Id == obj.PublicMember.Id);
            if (line == null)
            {
                line = new TransactionLine() { State = TransactionState.Error, Transaction = obj.PublicMember };
                line.OnReject += delegate
                {
                    ClientApiHelper.Instance.Api.DealCapture_Component.Transaction_StateMachine.SendEvent(line.Context, new Reject());
                };
                line.OnUpdateRequested += delegate
                {
                    ClientApiHelper.Instance.Api.DealCapture_Component.Transaction_StateMachine.SendEvent(line.Context, new Instrument() { Name = line.Transaction.Instrument });                    
                };
                Transactions.Add(line);
            }
            else
            {
                XComponent.Common.Clone.XCClone.Clone(obj.PublicMember, line.Transaction);
            }

            line.XCState = obj.StateName;
            line.Context = obj.Context;
        }

        void ValidationError_State_InstanceUpdated(TransactionInstance obj)
        {

        }

        void TransactionRejected_State_InstanceUpdated(TransactionInstance obj)
        {
            if (Application.Current.Dispatcher.Thread != Thread.CurrentThread)
            {
                Application.Current.Dispatcher.BeginInvoke(new Action<TransactionInstance>(TransactionRejected_State_InstanceUpdated), obj);
                return;
            }

            TransactionLine line = this.Transactions.FirstOrDefault(e => e.Transaction.Id == obj.PublicMember.Id);
            if (line == null)
            {
                line = new TransactionLine() { State = TransactionState.Rejected, Transaction = obj.PublicMember };
                Transactions.Add(line);
            }
            else
            {
                XComponent.Common.Clone.XCClone.Clone(obj.PublicMember, line.Transaction);
                line.State = TransactionState.Rejected;
            }

            line.XCState = obj.StateName;
            line.Context = obj.Context;
        }

        void TransactionAccepted_State_InstanceUpdated(TransactionInstance obj)
        {
            if (Application.Current.Dispatcher.Thread != Thread.CurrentThread)
            {
                Application.Current.Dispatcher.BeginInvoke(new Action<TransactionInstance>(TransactionAccepted_State_InstanceUpdated), obj);
                return;
            }

            TransactionLine line = this.Transactions.FirstOrDefault(e => e.Transaction.Id == obj.PublicMember.Id);
            if (line == null)
            {
                line = new TransactionLine() { State = TransactionState.Accepted, Transaction = obj.PublicMember };
                Transactions.Add(line);
            }
            else
            {
                XComponent.Common.Clone.XCClone.Clone(obj.PublicMember, line.Transaction);
                line.State = TransactionState.Accepted;
            }

            line.XCState = obj.StateName;
            line.Context = obj.Context;
        }
    }
}
