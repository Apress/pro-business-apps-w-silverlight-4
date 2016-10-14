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

namespace Chapter14Sample.Views
{
    public partial class MessageArrivedNotification : UserControl
    {
        private NotificationWindow window = null;

        public MessageArrivedNotification(NotificationWindow window)
        {
            InitializeComponent();

            this.window = window;
        }

        private void LayoutRoot_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.MainWindow.Activate();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            window.Close();
        }
    }
}
