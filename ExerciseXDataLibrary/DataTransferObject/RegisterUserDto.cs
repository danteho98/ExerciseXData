using ExerciseXData_UserLibrary.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExerciseXData_UserLibrary.DataTransferObject
{
    public class RegisterUserDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
            
        [Required]
        [DisplayName("Username")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$", 
            ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, and one number.")]
        public string Password { get; set; }

        [Required]
        [DisplayName("Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public UserGender.Gender Gender { get; set; }

        [Required]
        [Range(13, 120, ErrorMessage = "Age must be between 13 and 120.")]
        public int Age { get; set; }

        [DisplayName("Height (cm)")]
        [Required]
        [Range(50, 300, ErrorMessage = "Height must be between 50 cm and 300 cm.")]
        public double Height { get; set; }

        [Required]
        [DisplayName("Weight (kg)")]
        [Range(20, 500, ErrorMessage = "Weight must be between 20 kg and 500 kg.")]
        public double Weight { get; set; }

        [Required(ErrorMessage = "Please specify your goal.")]
        [MaxLength(200, ErrorMessage = "Goal cannot exceed 200 characters.")]
        public string Goal { get; set; }

        [DisplayName("Lifestyle Condition 1 (e.g., Vegetarian, Diabetic)")]
        public string ? LifestyleCondition1 { get; set; }

        [DisplayName("Lifestyle Condition 2 (optional)")]
        public string ? LifestyleCondition2 { get; set; }

        [DisplayName("Lifestyle Condition 3 (optional)")]
        public string ? LifestyleCondition3 { get; set; }

        [DisplayName("Lifestyle Condition 4 (optional)")]
        public string ? LifestyleCondition4 { get; set; }

        [DisplayName("Lifestyle Condition 5 (optional)")]
        public string ? LifestyleCondition5 { get; set; }
    }
}



