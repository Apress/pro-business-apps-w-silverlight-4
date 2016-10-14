using System;
using System.Collections.Generic;
using System.Threading;
using System.Web;
using SilverlightLOBFramework.Reports;
using Microsoft.Reporting.WebForms;

namespace Chapter13Sample.Web.Reports.Products
{
    public class ProductDetailsReportRenderer : BaseReportRenderer
    {
        #region Public Properties
        public override string ReportPath
        {
            get { return @"Reports\ProductDetailsReport.rdlc"; }
        }

        public override string ReportName
        {
            get { return "Product Details"; }
        }

        public override bool IsUserAccessAuthorised
        {
            get 
            {
                // Sample role checks (both methods have the same result):
                //return Thread.CurrentPrincipal.Identity.IsInRole("Managers");
                //return HttpContext.Current.User.IsInRole("Managers");
                return true; 
            }
        }
        #endregion

        #region Private Properties
        protected int ParamProductID
        {
            get
            {
                int paramValue = 0;
                const string paramName = "ProductID";

                if (Parameters[paramName] != null)
                    int.TryParse(Parameters[paramName], out paramValue);

                return paramValue;
            }
        }
        #endregion

        #region Public Functions
        public override void PopulateReportDataSources(ReportDataSourceCollection dataSources)
        {
            List<ProductDetailsReportData> productDetails = ProductDetailsReportData.GetProductDetailsByProductID(ParamProductID);
            dataSources.Add(new ReportDataSource("ProductDetails", productDetails));
        }
        #endregion
    }
}
