using System.ComponentModel.DataAnnotations;

namespace Medi_Connect.Models
{
    public class validCost:ValidationAttribute
    {
        public validCost() { }
        protected override ValidationResult IsValid(object value,ValidationContext validationContext)
        {
            int cost = int.Parse(value.ToString());

            if (cost > 0)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Cost must be greater than 0");
            }
        }
    }
}
