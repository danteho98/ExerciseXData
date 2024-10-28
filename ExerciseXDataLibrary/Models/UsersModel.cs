using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using ExerciseXDataLibrary.Models;

namespace ExerciseXData.Models
{
    public class UsersModel
    {
        [Key]
        [DisplayName("User Id")]
        public int U_Id { get; set; }

        [DisplayName ("Email")]
        public string ? U_Email { get; set; }
        
        [DisplayName ("User Name")]
        public string ? U_Name { get; set; }

        [DisplayName ("Gender")]
        public string ? Gender { get; set; }

        [DisplayName ("Age")]
        public int ? Age { get; set; }

        public string ? Role { get; set; }

        [DisplayName("Height (cm)")]
        public double ? Height { get; set; }

        [DisplayName("Weight (kg)")]
        public double ? Weight { get; set; }

        [DisplayName("Goal")]
        public string ? Goal { get; set; }

        [DisplayName("Lifestyle Condition 1")]
        public string ? Lifestyle_Condition_1 { get; set; }

        [DisplayName("Lifestyle Condition 2")]
        public string ? Lifestyle_Condition_2 { get; set; }

        [DisplayName ("Lifestyle Condition 3")]
        public string ? Lifestyle_Condition_3 { get; set; }

        [DisplayName ("Lifestyle Condition 4")]
        public string ? Lifestyle_Condition_4 { get; set; }

        [DisplayName ("Lifestyle Condition 5")]
        public string ? Lifestyle_Condition_5 { get; set; }

        [DisplayName("Created Date")]
        public DateTime U_Created_Date { get; set; } = DateTime.UtcNow;

        [DisplayName("Last Login")]
        public DateTime U_Last_Login {  get; set; }

        //Relationships
        public List<UsersCredentialsModel> UsersCredentials { get; set; }
        public List<UsersDietsModel> UsersDiets { get; set; }
        public List<UsersExercisesModel> UsersExercises { get; set; }


    }
}