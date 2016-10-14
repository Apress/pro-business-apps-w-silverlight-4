using System;
using System.Collections.Generic;
using Chapter13Sample.Web.Reports.Products;
using SilverlightLOBFramework;
using SilverlightLOBFramework.Reports;

namespace Chapter13Sample.Web
{
    public class Report : BaseReportHandler
    {
        #region Override Functions
        protected override void RegisterRenderers(Dictionary<string, Type> reportRenderers)
        {
            reportRenderers.Add("ProductDetails", typeof(ProductDetailsReportRenderer));
            reportRenderers.Add("ProductCatalog", typeof(ProductCatalogReportRenderer));
        }
        #endregion
    }
}
