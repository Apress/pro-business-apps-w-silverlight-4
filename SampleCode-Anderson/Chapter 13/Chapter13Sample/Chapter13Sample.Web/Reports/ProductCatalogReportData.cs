using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Chapter13Sample.Web;

namespace Chapter13Sample.Web.Reports.Products
{
    public class ProductCatalogReportData
    {
        #region Public Properties
        public string ProdSubCat { get; set; }
        public string ProdModel { get; set; }
        public string ProdCat { get; set; }
        public string Description { get; set; }
        public byte[] LargePhoto { get; set; }
        public string ProdName { get; set; }
        public string ProductNumber { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public decimal? Weight { get; set; }
        public decimal StandardCost { get; set; }
        public string Style { get; set; }
        public string Class { get; set; }
        public decimal ListPrice { get; set; }
        #endregion

        #region Factory Methods
        public static List<ProductCatalogReportData> GetProductCatalog()
        {
            using (AdventureWorks2008Entities context = new AdventureWorks2008Entities())
            {
                var reportData = from p in context.Products
                                 where p.ProductModel != null && p.ProductSubcategory != null
                                 select new ProductCatalogReportData()
                                 {
                                     ProdName = p.Name,
                                     ProductNumber = p.ProductNumber,
                                     ListPrice = p.ListPrice,
                                     Class = p.Class.TrimEnd(),
                                     Color = p.Color,
                                     Size = p.Size,
                                     StandardCost = p.StandardCost,
                                     Style = p.Style.TrimEnd(),
                                     Weight = p.Weight,
                                     ProdCat = p.ProductSubcategory.ProductCategory.Name,
                                     ProdSubCat = p.ProductSubcategory.Name,
                                     ProdModel = p.ProductModel.Name,
                                     LargePhoto = p.ProductProductPhotoes.FirstOrDefault().ProductPhoto.LargePhoto,
                                     Description = p.ProductModel.ProductModelProductDescriptionCultures.Where(x => x.CultureID == "en").FirstOrDefault().ProductDescription.Description
                                 };

                return reportData.ToList();
            }
        }
        #endregion
    }
}
