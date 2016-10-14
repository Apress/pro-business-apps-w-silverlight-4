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
using Chapter06Sample.Web.Models;

namespace Chapter06Sample.Views
{
    public partial class DataGridView : Page
    {
        public DataGridView()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void productSummaryDomainDataSource_LoadedData(object sender, LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                System.Windows.MessageBox.Show(e.Error.ToString(), "Load Error",
                                               System.Windows.MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }

        private void NameButton_Click(object sender, RoutedEventArgs e)
        {
            // Pop up a dialog to show details of the correspoding product
            HyperlinkButton button = sender as HyperlinkButton;
            ProductSummary productSummary = button.Tag as ProductSummary;

            ProductDetailsWindow window = new ProductDetailsWindow(productSummary);
            window.Show();
        }
    }
}
