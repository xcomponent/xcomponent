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
                Task.Factory.StartNew(() => ClientApiHelper.Instance.Init()).ContinueWith(t =>
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
                        var tradeCaptureViewModel = new TradeCreatorViewModel();
                        foreach (var instrument in t.Result.PublicMember.Instruments)
                        {
                            tradeCaptureViewModel.Instruments.Add(instrument);
                        }
                        tradeCaptureViewModel.SelectedInstrument = t.Result.PublicMember.Instruments.FirstOrDefault();
                        DataContext = tradeCaptureViewModel;
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Not connected to microservices !");
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
