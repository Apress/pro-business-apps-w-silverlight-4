namespace Chapter13Sample
{
    using System.Windows.Controls;
    using System.Windows.Navigation;
    using SilverlightLOBFramework.Reporting;

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

            this.Loaded += Home_Loaded;
        }

        private void Home_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            htmlViewer.Url = ReportRequest.GetReportUrl("ProductCatalog");
        }

        /// <summary>
        /// Executes when the user navigates to this page.
        /// </summary>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
}