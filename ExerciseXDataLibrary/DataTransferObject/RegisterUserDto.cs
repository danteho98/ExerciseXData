//using ExerciseXData_SharedLibrary.Enum;
using ExerciseXData_SharedLibrary.Enum;
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
        public Gender Gender { get; set; }

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

        [DisplayName("Fitness Goal")]
        [Required(ErrorMessage = "Please specify your goal.")]
        public FitnessGoal FitnessGoal { get; set; }

        [DisplayName("Activity Level")]
        public ActivityLevel U_ActivityLevel { get; set; }

        [DisplayName("Dietary Preferences")]
        public string DietaryPreferences { get; set; }

        //[DisplayName("Health Conditions")]
        //public List<string> HealthConditions { get; set; }

        [DisplayName("Sleep Patterns")]
        public SleepPattern SleepPatterns { get; set; }

        public bool ConsentToDataCollection { get; set; }
    }
}



