namespace Chapter04Sample
{
    using System.Windows.Controls;
    using System.Windows.Navigation;
    using System;

    /// <summary>
    /// Home page for the application.
    /// </summary>
    public partial class Home : Page
    {
        /// <summary>
        /// Creates a new <see cref="Home"/> instance.
        /// </summary>
        public Home()
        {
            InitializeComponent();

            this.Title = ApplicationStrings.HomePageTitle;
        }

        /// <summary>
        /// Executes when the user navigates to this page.
        /// </summary>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void NavigateFullQueryStringButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new System.Uri("ProductDetails?ProductID=" + ProductIDTextBox.Text, UriKind.Relative));
        }

        private void NavigateMappedQueryStringButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new System.Uri("ProductDetails/" + ProductIDTextBox.Text, UriKind.Relative));
        }
    }
}