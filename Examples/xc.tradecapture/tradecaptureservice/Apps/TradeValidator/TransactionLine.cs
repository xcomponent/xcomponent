using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using WpfApplication1.Commands;
using XComponent.Common.ApiContext;
using XComponent.Common.WPF;
using XComponent.TradeCapture.UserObject;

namespace WpfApplication1
{
    public class TransactionLine : INotifyPropertyChanged
    {
        private TransactionState _state;
        private string _xcState;
        private string _xcPreviousState;

        public event Action<TransactionLine> OnReject;
        public event Action<TransactionLine> OnUpdateRequested;

        public Transaction Transaction { get; set; }
        public Context Context { get; set; }


        public string XCState
        {
            get { return _xcState; }
            set
            {
                _xcState = value;
                this.NotifyPropertyChanged(PropertyChanged, ()=> XCState);
            }
        }

        public string XCPreviousState
        {
            get { return _xcPreviousState; }
            set
            {
                _xcPreviousState = value;
                this.NotifyPropertyChanged(PropertyChanged, () => XCPreviousState);
            }
        }

        public TransactionState State 
        {
            get { return _state; } 
            set
            {
                CommandManager.InvalidateRequerySuggested();
                this._state = value;
                this.NotifyPropertyChanged(PropertyChanged, ()=> State);
            } 
        }

        public ICommand UpdateCommand { get; private set; }
        public ICommand RejectCommand { get; private set; }

        public TransactionLine()
        {
            this.UpdateCommand = new UpdateCommand(this);
            this.RejectCommand = new RejectCommand(this);
        }

        public void UpdateAndRetry()
        {
            if(this.OnUpdateRequested != null)
            {
                this.OnUpdateRequested(this);
            }
        }

        public void Reject()
        {
            if(OnReject != null)
            {
                this.OnReject(this);
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

                    
    }
}
