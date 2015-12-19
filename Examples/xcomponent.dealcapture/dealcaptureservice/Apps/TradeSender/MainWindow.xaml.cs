using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace TradeSender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            Loaded += (sender, args) =>
            {
                ClientApiHelper.Instance.Init();
                Task.Factory.StartNew(() => true).ContinueWith(t =>
                {
                    if (t.Result)
                    {
                        return ClientApiHelper.Instance.Api.Referential_Component.GetEntryPoint();
                    }
                    return null;
                }).ContinueWith(t =>
                {
                    if (t.Result != null)
                    {
                        var dealCaptureViewModel = new DealCaptureViewModel();
                        foreach (var instrument in t.Result.PublicMember.Instruments)
                        {
                            dealCaptureViewModel.Instruments.Add(instrument);
                        }
                        dealCaptureViewModel.SelectedInstrument = t.Result.PublicMember.Instruments.FirstOrDefault();
                        DataContext = dealCaptureViewModel;
                    }
                } , TaskScheduler.FromCurrentSynchronizationContext());
            };
        
        }

        private void Window_Closed(object sender, EventArgs e)
        {
          ClientApiHelper.Instance.Dispose();
        }
    }
}
