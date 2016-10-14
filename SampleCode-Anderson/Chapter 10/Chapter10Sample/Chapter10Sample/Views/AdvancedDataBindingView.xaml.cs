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
using Chapter10Sample.Models;

namespace Chapter10Sample.Views
{
    public partial class AdvancedDataBindingView : Page
    {
        public AdvancedDataBindingView()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void DisplayValueButton_Click(object sender, RoutedEventArgs e)
        {
            var data = ((Button)sender).DataContext as AdvancedDataBindingSourceData;
            MessageBox.Show(data.AgeBracket.ToString());
        }

    }
}
