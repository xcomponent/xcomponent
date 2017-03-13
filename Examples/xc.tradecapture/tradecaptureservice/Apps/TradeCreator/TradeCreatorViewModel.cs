using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Input;

namespace TradeSender
{
    class CreateTransactionCommand : ICommand
    {
        readonly private TradeCreatorViewModel _dealCaptureViewModel;
        public CreateTransactionCommand(TradeCreatorViewModel dealCaptureViewModel)
        {
            _dealCaptureViewModel = dealCaptureViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_dealCaptureViewModel.SelectedInstrument);
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
             ClientApiHelper.Instance.Api.TradeCapture_Component.XCTradeProcessor_StateMachine.SendEvent(
                new XComponent.TradeCapture.UserObject.Transaction()
                {
                    ExecutionDate = _dealCaptureViewModel.DealMaturity,
                    Instrument = _dealCaptureViewModel.SelectedInstrument,
                    Price = _dealCaptureViewModel.DealAmountInt
                });
        }
    }
    class TradeCreatorViewModel: INotifyPropertyChanged
    {
        private int _dealAmount = 100;
        private DateTime _dealMaturity = DateTime.Now;
        private string _selectedInstrument = String.Empty;
        public ObservableCollection<string> Instruments { get; set; }

        public TradeCreatorViewModel()
        {
            Instruments = new ObservableCollection<string>();
            CreateTransactionCommand = new CreateTransactionCommand(this);
            ClientApiHelper.Instance.Api.Referential_Component.Referential_StateMachine.Referential_State.InstanceUpdated += Referential_StateMachine_InstanceUpdated;
        }

        public string DealAmount
        {
            get { return _dealAmount.ToString(CultureInfo.InvariantCulture); }
            set
            {
                int dVal;
                if (int.TryParse(value, out dVal))
                {
                    _dealAmount = dVal;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DealAmount)));
                }
            }
        }

        public int DealAmountInt
        {
            get
            {
                return _dealAmount;
            }
        }

        public string SelectedInstrument
        {
            get { return _selectedInstrument; }
            set
            {
                if (_selectedInstrument != value)
                {
                    _selectedInstrument = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedInstrument)));
                }
            }
        }

        public DateTime DealMaturity
        {
            get { return _dealMaturity; }
            set
            {
                _dealMaturity = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DealMaturity)));
            }
        }

        public ICommand CreateTransactionCommand { get; private set; }



        private void UpdateInstruments(IEnumerable<string> instruments)
        {
            foreach (string instrument in instruments)
            {
                if (!Instruments.Contains(instrument))
                {
                    Instruments.Add(instrument);                    
                }
            }
        }
        void Referential_StateMachine_InstanceUpdated(XComponent.TradeCapture.TradeApi.Referential.ReferentialInstance referentialInstance)
        {
            Application.Current.Dispatcher.BeginInvoke((Action) delegate
            {
                UpdateInstruments(referentialInstance.PublicMember.Instruments);
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
