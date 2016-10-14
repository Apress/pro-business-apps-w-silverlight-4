using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.DomainServices.Hosting;
using System.ServiceModel.DomainServices.Server;
using Chapter05Sample.Web.Models;

namespace Chapter05Sample.Web.Services
{
    [EnableClientAccess()]
    public class ProductPMService : DomainService
    {
        private AdventureWorks2008Entities context = new AdventureWorks2008Entities();

        public IQueryable<ProductPM> GetProducts()
        {
            return from p in context.Products
                   select new ProductPM()
                   {
                       ProductID = p.ProductID,
                       Name = p.Name,
                       ProductNumber = p.ProductNumber,
                       ListPrice = p.ListPrice,
                       ModifiedDate = p.ModifiedDate
                   };
        }

        public ProductPM GetProduct(int productID)
        {
            var qry = from p in context.Products
                      where p.ProductID == productID
                      select new ProductPM()
                      {
                          ProductID = p.ProductID,
                          Name = p.Name,
                          ProductNumber = p.ProductNumber,
                          ListPrice = p.ListPrice,
                          ModifiedDate = p.ModifiedDate
                      };

            return qry.FirstOrDefault();
        }

        public void InsertProduct(ProductPM productPM)
        {
            Product product = new Product();
            product.Name = productPM.Name;
            product.ProductNumber = productPM.ProductNumber;
            product.ListPrice = productPM.ListPrice;
            product.ModifiedDate = DateTime.Now;
            context.Products.AddObject(product);
            context.SaveChanges();

            ChangeSet.Associate(productPM, product, UpdateProductPMKeys);
        }

        public void UpdateProduct(ProductPM productPM)
        {
            ProductPM originalProduct = ChangeSet.GetOriginal<ProductPM>(productPM);
            ProductPM storedProduct = GetProduct(productPM.ProductID);

            if (storedProduct.ModifiedDate != originalProduct.ModifiedDate)
            {
                ChangeSetEntry entry = ChangeSet.ChangeSetEntries.Single(p => p.Entity == productPM);

                List<string> conflicts = new List<string>();
                conflicts.Add("ModifiedDate");
                entry.ConflictMembers = conflicts;

                entry.IsDeleteConflict = false;
                entry.StoreEntity = storedProduct;
            }
            else
            {
                // Save ProductPM...
                Product product = new Product();
                product.Name = productPM.Name;
                product.ProductNumber = productPM.ProductNumber;
                product.ListPrice = productPM.ListPrice;
                product.ModifiedDate = DateTime.Now;
                context.Products.AddObject(product);
                context.SaveChanges();

                ChangeSet.Associate(productPM, product, UpdateProductPMKeys);
            }
        }

        public void DeleteProduct(ProductPM productPM)
        {
            Product product = new Product();
            product.ProductID = productPM.ProductID;
            context.Products.DeleteObject(product);
        }

        private void UpdateProductPMKeys(ProductPM productPM, Product product)
        {
            productPM.ProductID = product.ProductID;
            productPM.ModifiedDate = product.ModifiedDate;
        }
    }
}
