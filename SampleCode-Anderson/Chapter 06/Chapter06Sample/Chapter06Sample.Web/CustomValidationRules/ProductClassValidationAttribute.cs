using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Chapter06Sample.Web.CustomValidationRules
{
    public class ProductClassValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string productClass = value.ToString();
            bool isValid = false;

            string[] validClasses = new string[] { "H", "M", "L", "" };
            isValid = validClasses.Contains(productClass.ToUpper());

            return isValid ? ValidationResult.Success : new ValidationResult("The class is invalid");
        }
    }
}
