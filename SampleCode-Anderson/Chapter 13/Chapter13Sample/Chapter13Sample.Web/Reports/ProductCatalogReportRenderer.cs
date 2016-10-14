using System;
using System.Collections.Generic;
using Microsoft.Reporting.WebForms;
using SilverlightLOBFramework.Reports;

namespace Chapter13Sample.Web.Reports.Products
{
    public class ProductCatalogReportRenderer : BaseReportRenderer
    {
        #region Public Properties
        public override string ReportPath
        {
            get { return @"Reports\Product Catalog.rdlc"; }
        }

        public override string ReportName
        {
            get { return "Product Catalog"; }
        }
        #endregion

        #region Public Functions
        public override void PopulateReportDataSources(ReportDataSourceCollection dataSources)
        {
            List<ProductCatalogReportData> productCatalogReportData = ProductCatalogReportData.GetProductCatalog();
            dataSources.Add(new ReportDataSource("ProductCatalog", productCatalogReportData));
        }
        #endregion
    }
}