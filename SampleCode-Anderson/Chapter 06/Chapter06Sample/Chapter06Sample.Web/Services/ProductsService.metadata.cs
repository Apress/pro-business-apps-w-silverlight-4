#pragma warning disable 649    // disable compiler warnings about unassigned fields

namespace Chapter06Sample.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Chapter06Sample.Web.CustomValidationRules;


    // The MetadataTypeAttribute identifies ProductMetadata as the class
    // that carries additional metadata for the Product class.
    [MetadataTypeAttribute(typeof(Product.ProductMetadata))]
    public partial class Product
    {

        // This class allows you to attach custom attributes to properties
        // of the Product class.
        //
        // For example, the following marks the Xyz property as a
        // required field and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz;
        [SellDatesValidation] // A custom class level validation rule
        internal sealed class ProductMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private ProductMetadata()
            {
            }

            [ProductClassValidation] // A custom validation rule
            public string Class;

            public string Color;

            public int DaysToManufacture;

            public Nullable<DateTime> DiscontinuedDate;

            public bool FinishedGoodsFlag;

            public decimal ListPrice;

            public bool MakeFlag;

            [ConcurrencyCheck]
            public DateTime ModifiedDate;

            [Required] // An predefined validation rule
            public string Name;

            public int ProductID;

            public string ProductLine;

            public Nullable<int> ProductModelID;

            public string ProductNumber;

            public Nullable<int> ProductSubcategoryID;

            public short ReorderPoint;

            public Guid rowguid;

            public short SafetyStockLevel;

            public Nullable<DateTime> SellEndDate;

            public DateTime SellStartDate;

            public string Size;

            public string SizeUnitMeasureCode;

            public decimal StandardCost;

            public string Style;

            public Nullable<decimal> Weight;

            public string WeightUnitMeasureCode;
        }
    }
}

#pragma warning restore 649    // re-enable compiler warnings about unassigned fields
