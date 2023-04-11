using System.ComponentModel.DataAnnotations;

namespace HotSalesCore.AttributeValidations
{
    public class ValidateGenderAttribute: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || String.IsNullOrEmpty(value.ToString())) return ValidationResult.Success;

            string[] valores = { "M", "F" };

            if (valores.Contains(value.ToString())) return ValidationResult.Success;

            return new ValidationResult("The Gender field must be 'M' or 'F'");
        }
    }
}
