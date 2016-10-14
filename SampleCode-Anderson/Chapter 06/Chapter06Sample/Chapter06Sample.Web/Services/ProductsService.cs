
namespace Chapter06Sample.Web.Services
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Linq;
    using Chapter06Sample.Web;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.EntityFramework;
    using System.ServiceModel.DomainServices.Server;
    using Chapter06Sample.Web.Models;
    using System.IO;
    using System.Drawing.Imaging;
    using System.Drawing;

    // [RequiresAuthentication]
    [EnableClientAccess()]
    public class ProductsService : LinqToEntitiesDomainService<AdventureWorks2008Entities>
    {
        public IQueryable<ProductSummary> GetProductSummaryList()
        {
            return from p in this.ObjectContext.Products
                   orderby p.Name
                   select new ProductSummary()
                   {
                       ID = p.ProductID,
                       Name = p.Name,
                       Number = p.ProductNumber,
                       ListPrice = p.ListPrice,
                       ThumbnailPhoto = p.ProductProductPhotoes.FirstOrDefault().ProductPhoto.ThumbNailPhoto,
                       QuantityAvailable = p.ProductInventories.Sum(pi => pi.Quantity),
                       Category = p.ProductSubcategory.ProductCategory.Name,
                       Subcategory = p.ProductSubcategory.Name,
                       Model = p.ProductModel.Name,
                       MakeFlag = p.MakeFlag
                   };
        }

        public IQueryable<Product> GetProducts()
        {
            return this.ObjectContext.Products;
        }

        public Product GetProduct(int productID)
        {
            return this.ObjectContext.Products.First(p => p.ProductID == productID);
        }

        protected override void OnError(DomainServiceErrorInfo errorInfo)
        {
            base.OnError(errorInfo);
        }

        public void InsertProduct(Product product)
        {
            if ((product.EntityState != EntityState.Added))
            {
                if ((product.EntityState != EntityState.Detached))
                {
                    this.ObjectContext.ObjectStateManager.
                        ChangeObjectState(product, EntityState.Added);
                }
                else
                {
                    this.ObjectContext.AddToProducts(product);
                }
            }
        }

        public void UpdateProduct(Product currentProduct)
        {
            if ((currentProduct.EntityState == EntityState.Detached))
            {
                this.ObjectContext.Products.AttachAsModified(currentProduct, this.ChangeSet.GetOriginal(currentProduct));
            }
        }

        public void DeleteProduct(Product product)
        {
            if ((product.EntityState == EntityState.Detached))
            {
                this.ObjectContext.Attach(product);
            }
            this.ObjectContext.DeleteObject(product);
        }
    }
}


