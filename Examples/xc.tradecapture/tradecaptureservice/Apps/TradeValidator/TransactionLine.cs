using System;
using System.ComponentModel;
using System.Windows.Input;
using WpfApplication1.Commands;
using XComponent.Common.ApiContext;
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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(XCState)));
            }
        }

        public string XCPreviousState
        {
            get { return _xcPreviousState; }
            set
            {
                _xcPreviousState = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(XCPreviousState))); 
            }
        }

        public TransactionState State 
        {
            get { return _state; } 
            set
            {
                CommandManager.InvalidateRequerySuggested();
                _state = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(State)));
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
            OnUpdateRequested?.Invoke(this);
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
