using System.ComponentModel.DataAnnotations;

namespace WebAPI_MinimalAPI.Models.Validations
{
    public class Shirt_EnsureCorrectSizeAttribute: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var shirt = validationContext.ObjectInstance as Shirt;
            
            if (shirt != null && !string.IsNullOrWhiteSpace(shirt.Gender)) {
                if (shirt.Gender.Equals("men", StringComparison.InvariantCultureIgnoreCase) && shirt.Size < 8)
                    return new ValidationResult("The size of the shirt has to be at least 8 for men");
                else if (shirt.Gender.Equals("women", StringComparison.InvariantCultureIgnoreCase) && shirt.Size < 6)
                    return new ValidationResult("The size of the shirt has to be at least 6 for women");
            }
            return ValidationResult.Success;
        }
    }
}
