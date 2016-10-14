using System;
using System.Linq;
using System.ServiceModel.DomainServices.Client;
using System.Windows.Input;
using Chapter12Sample.Web;
using Chapter12Sample.Web.Services;
using SimpleMVVM;

namespace Chapter12Sample.ViewModels
{
    public class ProductDetailsViewModel : ViewModelBase
    {
        #region Member Variables
        private ProductContext _context = new ProductContext();
        private Product _product = null; 
        #endregion

        #region Public Properties
        public Product Product
        {
            get { return _product; }
            set
            {
                _product = value;
                OnPropertyChanged(() => Product);
            }
        } 
        #endregion

        #region Commands
        public ICommand LoadProduct
        {
            get
            {
                return new DelegateCommand(BeginLoadProduct, (o) => true);
            }
        }
        #endregion

        #region Server Calls (and Completed event handlers)
        public void BeginLoadProduct(object param)
        {
            int productID = Convert.ToInt32(param);

            var op = _context.Load(_context.GetProductQuery(productID), true);
            op.Completed += LoadProduct_Completed;
        }

        private void LoadProduct_Completed(object sender, EventArgs e)
        {
            LoadOperation op = sender as LoadOperation;

            if (!op.HasError && op.Entities.Count() != 0)
            {
                this.Product = op.Entities.First() as Product;
            }
            else
            {
                // Handle this error appropriately - omitted for brevity
                this.Product = null;
            }
        }

        public void BeginSaveProduct()
        {
            if (_product != null)
            {
                var op = _context.SubmitChanges();
                op.Completed += new EventHandler(SaveProduct_Completed);
            }
        }

        private void SaveProduct_Completed(object sender, EventArgs e)
        {
            SubmitOperation op = sender as SubmitOperation;

            if (!op.HasError)
            {
                // You may wish to notify the view that the save is complete
                // by raising an event here, and responding to it in the view
            }
            else
            {
                // Handle this error appropriately - omitted for brevity
            }
        } 
        #endregion
    }
}
