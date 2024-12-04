
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
//using ExerciseXData_SharedLibrary.Enum;
using Microsoft.AspNetCore.Identity;

namespace ExerciseXData_UserLibrary.Models
{

    public class UsersModel : IdentityUser
    {
        //public Gender U_UserGender { get; set; }

        [DisplayName ("Age")]
        public int U_Age { get; set; }

        [DisplayName("Height (cm)")]
        public double U_Height_CM { get; set; }

        [DisplayName("Weight (kg)")]
        [Range(0, 500, ErrorMessage = "Weight must be between 0 and 500.")]
        public double U_Weight_KG { get; set; }

        //[DisplayName("Fitness Goal")]
        //public FitnessGoal FitnessGoal { get; set; } // Fitness Goals

        //[DisplayName("Activity Level")]
        //public ActivityLevel U_ActivityLevel { get; set; }

        [DisplayName("Dietary Preferences")]
        public string DietaryPreferences { get; set; } // Dietary Preferences

        //[DisplayName("Health Conditions")]
        //public List<HealthCondition> HealthConditions { get; set; }

        //[DisplayName("Sleep Patterns")]
        //public SleepPattern SleepPatterns { get; set; }

        [DisplayName("Created Date")]
        public DateTime U_Created_Date { get; set; } = DateTime.UtcNow;

        [DisplayName("Last Login")]
        public DateTime U_Last_Login {  get; set; } = DateTime.UtcNow;

        public bool ConsentToDataCollection { get; set; }
        public ICollection<UserSecurityQuestionModel> UserSecurityQuestions { get; set; }

    }
}