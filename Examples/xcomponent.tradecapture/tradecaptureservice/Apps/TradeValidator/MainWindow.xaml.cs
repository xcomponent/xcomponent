using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace WpfApplication1
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
                        DataContext = new BlotterViewModel();
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Not connected to microservices !");
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());
            };

        }

      

        private void Window_Closed(object sender, EventArgs e)
        {
           ClientApiHelper.Instance.Api.Dispose();
        }
    }
}
