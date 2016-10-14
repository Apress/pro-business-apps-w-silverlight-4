using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Chapter05Sample.Web.Models
{
    public partial class ProductPM
    {
        [Key]
        [Editable(false)]
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public decimal ListPrice { get; set; }

        [ConcurrencyCheck]
        public DateTime ModifiedDate { get; set; }
    }
}
