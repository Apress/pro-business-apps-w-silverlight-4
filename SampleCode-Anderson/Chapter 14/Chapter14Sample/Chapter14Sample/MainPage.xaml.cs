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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chapter14Sample
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            // Only show the title bar and resize handle when running outside the browser
            TitleBar.Visibility = (Application.Current.IsRunningOutOfBrowser) ? Visibility.Visible : Visibility.Collapsed;
            ResizeHandle.Visibility = (Application.Current.IsRunningOutOfBrowser) ? Visibility.Visible : Visibility.Collapsed;
            CloseButton.Visibility = (Application.Current.IsRunningOutOfBrowser) ? Visibility.Visible : Visibility.Collapsed;

            COMButton.Visibility = (Application.Current.IsRunningOutOfBrowser && Application.Current.HasElevatedPermissions) ? Visibility.Visible : Visibility.Collapsed;
        }

        // After the Frame navigates, ensure the HyperlinkButton representing the current page is selected
        private void ContentFrame_Navigated(object sender, NavigationEventArgs e)
        {
            foreach (UIElement child in LinksStackPanel.Children)
            {
                HyperlinkButton hb = child as HyperlinkButton;
                if (hb != null && hb.NavigateUri != null)
                {
                    if (ContentFrame.UriMapper.MapUri(e.Uri).ToString().Equals(ContentFrame.UriMapper.MapUri(hb.NavigateUri).ToString()))
                    {
                        VisualStateManager.GoToState(hb, "ActiveLink", true);
                    }
                    else
                    {
                        VisualStateManager.GoToState(hb, "InactiveLink", true);
                    }
                }
            }
        }

        // If an error occurs during navigation, show an error window
        private void ContentFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            e.Handled = true;
            ChildWindow errorWin = new ErrorWindow(e.Uri);
            errorWin.Show();
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Initiate the moving of the window
            Application.Current.MainWindow.DragMove();
        }

        private void ResizeHandle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Initiate the resizing of the window
            Application.Current.MainWindow.DragResize(WindowResizeEdge.BottomRight);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }
    }
}