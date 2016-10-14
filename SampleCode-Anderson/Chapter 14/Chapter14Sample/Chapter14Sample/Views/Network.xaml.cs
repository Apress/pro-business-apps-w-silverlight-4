using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Navigation;
using System.Net.NetworkInformation;

namespace Chapter14Sample.Views
{
    public partial class Network : Page
    {
        public Network()
        {
            InitializeComponent();

            NetworkChange.NetworkAddressChanged += NetworkChange_NetworkAddressChanged;
            UpdateNetworkAvailabilityUI();
        }

        private void NetworkChange_NetworkAddressChanged(object sender, EventArgs e)
        {
            UpdateNetworkAvailabilityUI();
        }

        private void UpdateNetworkAvailabilityUI()
        {
            NetworkStateIndicator.IsChecked = NetworkInterface.GetIsNetworkAvailable();

            //if (NetworkInterface.GetIsNetworkAvailable())
            //{
            //    NetworkStateBorder.Background = new SolidColorBrush(Colors.Green);
            //    NetworkStateText.Text = "A network connection is available";
            //}
            //else
            //{
            //    NetworkStateBorder.Background = new SolidColorBrush(Colors.Red);
            //    NetworkStateText.Text = "No network connection is available";
            //}
        }
    }
}
