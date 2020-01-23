using System;
using System.ComponentModel.DataAnnotations;

namespace StreamDream.Models
{
    public class Min18YearsIfMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == 1)
            {
                return ValidationResult.Success;
            }
            if (customer.Birthdate == null)
            {
                return new ValidationResult("Birthdate is required");
            }
            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;
            if (!(age >= 18))
            {
                return new ValidationResult("Customer should be atleast 18 years old to be a member.");
            }
            else
            {
                return ValidationResult.Success;

            }
        }
    }
}