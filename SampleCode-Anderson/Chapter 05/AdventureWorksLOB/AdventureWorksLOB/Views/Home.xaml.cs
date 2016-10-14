namespace AdventureWorksLOB
{
    using System.Windows.Controls;
    using System.Windows.Navigation;
    using AdventureWorksLOB.Resources;
    using AdventureWorksMiddleTier.Web.Services;
    using AdventureWorksMiddleTier.Web;
    using System.Net;
    using System;

    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();

            this.Title = ApplicationStrings.HomePageTitle;
        }

        /// <summary>
        ///     Executes when the user navigates to this page.
        /// </summary>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
}