using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Chapter06Sample.Web.Models
{
    public class ProductSummary
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public decimal ListPrice { get; set; }
        public int? QuantityAvailable { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
        public string Model { get; set; }
        public byte[] ThumbnailPhoto { get; set; }
        public bool MakeFlag { get; set; }
    }
}
