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
        public string ? LifestyleCondition1 { get; set; }
        public string ? LifestyleCondition2 { get; set; }
        public string ? LifestyleCondition3 { get; set; }
        public string ? LifestyleCondition4 { get; set; }
        public string ? LifestyleCondition5 { get; set; }
    }
}



