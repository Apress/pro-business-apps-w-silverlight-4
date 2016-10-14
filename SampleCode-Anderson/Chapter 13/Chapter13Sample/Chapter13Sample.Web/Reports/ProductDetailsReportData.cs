using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Chapter13Sample.Web;

namespace Chapter13Sample.Web.Reports.Products
{
    public class ProductDetailsReportData
    {
        #region Public Properties
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public string ProductLine { get; set; }
        public string Size { get; set; }
        public DateTime SellStartDate { get; set; }
        public DateTime? SellEndDate { get; set; }
        public DateTime? DiscontinuedDate { get; set; }
        public decimal ListPrice { get; set; }
        public string Class { get; set; }
        public string Color { get; set; }
        public string Style { get; set; }
        public int? CategoryID { get; set; }
        public int? SubcategoryID { get; set; }
        public int? ModelID { get; set; }
        public string CategoryName { get; set; }
        public string SubcategoryName { get; set; }
        public string ModelName { get; set; }
        public int DaysToManufacture { get; set; }
        public bool FinishedGoodsFlag { get; set; }
        public bool MakeFlag { get; set; }
        public short ReorderPoint { get; set; }
        public short SafetyStockLevel { get; set; }
        public decimal StandardCost { get; set; }
        public decimal? Weight { get; set; }
        public string SizeMeasureUnitCode { get; set; }
        public string WeightMeasureUnitCode { get; set; }
        public string SizeMeasureUnitDescription { get; set; }
        public string WeightMeasureUnitDescription { get; set; } 
        #endregion

        #region Factory Methods
        public static List<ProductDetailsReportData> GetProductDetailsByProductID(int productID)
        {
            using (AdventureWorks2008Entities context = new AdventureWorks2008Entities())
            {
                var reportData = from p in context.Products.Include("ProductSubcategory")
                                                           .Include("ProductCategory")
                                                           .Include("ProductModel")
                                 where p.ProductID == productID
                                 select new ProductDetailsReportData()
                                 {
                                     ProductID = p.ProductID,
                                     Name = p.Name,
                                     ProductNumber = p.ProductNumber,
                                     ListPrice = p.ListPrice,
                                     Class = p.Class.TrimEnd(),
                                     Color = p.Color,
                                     DaysToManufacture = p.DaysToManufacture,
                                     DiscontinuedDate = p.DiscontinuedDate,
                                     FinishedGoodsFlag = p.FinishedGoodsFlag,
                                     MakeFlag = p.MakeFlag,
                                     ModelID = p.ProductModel.ProductModelID,
                                     ProductLine = p.ProductLine.TrimEnd(),
                                     ReorderPoint = p.ReorderPoint,
                                     SafetyStockLevel = p.SafetyStockLevel,
                                     SellEndDate = p.SellEndDate,
                                     SellStartDate = p.SellStartDate,
                                     Size = p.Size,
                                     StandardCost = p.StandardCost,
                                     Style = p.Style.TrimEnd(),
                                     SubcategoryID = p.ProductSubcategory.ProductSubcategoryID,
                                     CategoryID = p.ProductSubcategory.ProductCategory.ProductCategoryID,
                                     Weight = p.Weight,
                                     SizeMeasureUnitCode = p.UnitMeasure.UnitMeasureCode,
                                     WeightMeasureUnitCode = p.UnitMeasure1.UnitMeasureCode,
                                     CategoryName = p.ProductSubcategory.ProductCategory.Name,
                                     SubcategoryName = p.ProductSubcategory.Name,
                                     ModelName = p.ProductModel.Name,
                                     SizeMeasureUnitDescription = p.UnitMeasure.Name,
                                     WeightMeasureUnitDescription = p.UnitMeasure1.Name
                                 };

                return reportData.ToList();
            }
        } 
        #endregion
    }
}
