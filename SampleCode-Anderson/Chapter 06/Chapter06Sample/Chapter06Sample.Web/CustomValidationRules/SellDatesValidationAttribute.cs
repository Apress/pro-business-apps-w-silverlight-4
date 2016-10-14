using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Chapter06Sample.Web.CustomValidationRules
{
    public class SellDatesValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Product product = value as Product;
            return product.SellEndDate > product.SellStartDate ? ValidationResult.Success : new ValidationResult("The sell end date must be greater than the sell start date");
        }
    }
}
