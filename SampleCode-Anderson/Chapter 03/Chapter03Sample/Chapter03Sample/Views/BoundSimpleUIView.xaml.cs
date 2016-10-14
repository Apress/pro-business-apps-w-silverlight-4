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
using Chapter03Sample;

namespace Chapter03Sample.Views
{
    public partial class BoundSimpleUIView : Page
    {
        public BoundSimpleUIView()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            Person person = LayoutRoot.DataContext as Person;
            MessageBox.Show("Hello " + person.FirstName + " " + person.LastName);
        }
    }
}
