using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using XComponent.Common.WPF;
using XComponent.DealCapture.DealApi.Referential;

namespace TradeSender
{
    class CreateTransactionCommand : ICommand
    {
        readonly private DealCaptureViewModel _dealCaptureViewModel;
        public CreateTransactionCommand(DealCaptureViewModel dealCaptureViewModel)
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
             ClientApiHelper.Instance.Api.DealCapture_Component.XCTradeProcessor_StateMachine.SendEvent(
                new XComponent.DealCapture.UserObject.Transaction()
                {
                    ExecutionDate = _dealCaptureViewModel.DealMaturity,
                    Instrument = _dealCaptureViewModel.SelectedInstrument,
                    Price = _dealCaptureViewModel.DealAmountInt
                });
        }
    }
    class DealCaptureViewModel: INotifyPropertyChanged
    {
        private int _dealAmount = 100;
        private DateTime _dealMaturity = DateTime.Now;
        private string _selectedInstrument = String.Empty;
        public ObservableCollection<string> Instruments { get; set; }

        public DealCaptureViewModel()
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
                    this.NotifyPropertyChanged(PropertyChanged, ()=> DealAmount);
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
                    this.NotifyPropertyChanged(PropertyChanged, () => SelectedInstrument);
                }
            }
        }

        public DateTime DealMaturity
        {
            get { return _dealMaturity; }
            set
            {
                _dealMaturity = value;
                this.NotifyPropertyChanged(PropertyChanged, () => DealMaturity);
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
        void Referential_StateMachine_InstanceUpdated(XComponent.DealCapture.DealApi.Referential.ReferentialInstance referentialInstance)
        {
            Application.Current.Dispatcher.BeginInvoke((Action) delegate
            {
                UpdateInstruments(referentialInstance.PublicMember.Instruments);
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
