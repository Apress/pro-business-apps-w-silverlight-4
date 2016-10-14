using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter05Sample.Web
{
    public partial class Product
    {
        public decimal ProfitMargin
        {
            get { return ListPrice - StandardCost; }
        }
    }
}
