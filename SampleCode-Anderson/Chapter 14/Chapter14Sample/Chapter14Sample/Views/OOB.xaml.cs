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
using System.ComponentModel;

namespace Chapter14Sample.Views
{
    public partial class OOB : Page
    {
        private NotificationWindow toastWindow = null;

        public OOB()
        {
            InitializeComponent();

            InstallButton.Visibility = (Application.Current.InstallState == InstallState.NotInstalled) ? Visibility.Visible : Visibility.Collapsed;
            ToastButton.Visibility = (Application.Current.IsRunningOutOfBrowser) ? Visibility.Visible : Visibility.Collapsed;
            CheckUpdateButton.Visibility = (Application.Current.IsRunningOutOfBrowser) ? Visibility.Visible : Visibility.Collapsed;

            Application.Current.InstallStateChanged += Application_InstallStateChanged;
            Application.Current.CheckAndDownloadUpdateCompleted += Application_CheckAndDownloadUpdateCompleted;
        }

        private void MainWindow_Closing(object sender, ClosingEventArgs e)
        {
            if (e.IsCancelable)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you wish to quit?", "Chapter 14 Sample", MessageBoxButton.OKCancel);
                e.Cancel = (result != MessageBoxResult.OK);
            }
        }

        private void Application_InstallStateChanged(object sender, EventArgs e)
        {
            // Handle the state change as required here
            InstallButton.Visibility = (Application.Current.IsRunningOutOfBrowser) ? Visibility.Visible : Visibility.Collapsed;
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void InstallButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Application.Current.Install();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CheckUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.CheckAndDownloadUpdateAsync();
        }

        private void Application_CheckAndDownloadUpdateCompleted(object sender, CheckAndDownloadUpdateCompletedEventArgs e)
        {
            if (e.UpdateAvailable)
            {
                MessageBox.Show("Update found! Please restart the application...");
            }
            else
            {
                MessageBox.Show("No update found...");
            }
        }

        private void ToastButton_Click(object sender, RoutedEventArgs e)
        {
            if (App.Current.IsRunningOutOfBrowser)
            {
                if (toastWindow != null && toastWindow.Visibility == Visibility.Visible)
                    toastWindow.Close();

                toastWindow = new NotificationWindow();
                toastWindow.Width = 280;
                toastWindow.Height = 100;
                toastWindow.Content = new MessageArrivedNotification(toastWindow);
                toastWindow.Show(4000);
            }
        }
    }
}
