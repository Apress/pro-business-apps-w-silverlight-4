
namespace Chapter12Sample.Web.Services
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Linq;
    using System.ServiceModel.DomainServices.EntityFramework;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using Chapter12Sample.Web;


    // Implements application logic using the AdventureWorksEntities context.
    // TODO: Add your application logic to these methods or in additional methods.
    // TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
    // Also consider adding roles to restrict access as appropriate.
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public class ProductService : LinqToEntitiesDomainService<AdventureWorksEntities>
    {

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Products' query.
        public IQueryable<Product> GetProducts()
        {
            return this.ObjectContext.Products;
        }

        public Product GetProduct(int productID)
        {
            return this.ObjectContext.Products.FirstOrDefault(p => p.ProductID == productID);
        }

        public void InsertProduct(Product product)
        {
            if ((product.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(product, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Products.AddObject(product);
            }
        }

        public void UpdateProduct(Product currentProduct)
        {
            this.ObjectContext.Products.AttachAsModified(currentProduct, this.ChangeSet.GetOriginal(currentProduct));
        }

        public void DeleteProduct(Product product)
        {
            if ((product.EntityState == EntityState.Detached))
            {
                this.ObjectContext.Products.Attach(product);
            }
            this.ObjectContext.Products.DeleteObject(product);
        }
    }
}


