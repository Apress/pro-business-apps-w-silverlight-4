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

namespace Chapter04Sample.Views
{
    public partial class ProductDetails : Page
    {
        public ProductDetails()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ProductIDText.Text = ParamProductID.ToString();
        }

        private int ParamProductID
        {
            get
            {
                int paramValue = 0;
                const string paramName = "ProductID";

                if (NavigationContext.QueryString.ContainsKey(paramName))
                    int.TryParse(NavigationContext.QueryString[paramName], out paramValue);

                return paramValue;
            }
        }
    }
}
