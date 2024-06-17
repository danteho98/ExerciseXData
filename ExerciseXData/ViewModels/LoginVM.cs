using System.ComponentModel.DataAnnotations;

namespace ExerciseXData.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email address is required")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
                        ErrorMessage = "The password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one digit, and one special character.")]
        public string Password { get; set; }
    }
}