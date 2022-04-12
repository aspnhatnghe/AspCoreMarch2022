using System;
using System.ComponentModel.DataAnnotations;

namespace Buoi09_Validation.Models
{
    public class CheckBirthDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                var myBirthDate = (DateTime)value;
                if (DateTime.Now.Year - myBirthDate.Year < 10)
                {
                    return new ValidationResult("Không đủ tuổi làm việc");
                }
                return ValidationResult.Success;
            }
            catch
            {
                return new ValidationResult("Invalid datetime");
            }
        }
    }
}