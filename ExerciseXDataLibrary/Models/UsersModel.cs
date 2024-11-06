using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ExerciseXDataLibrary.Models
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
        public double ? Height_CM { get; set; }

        [DisplayName("Weight (kg)")]
        public double ? Weight_KG { get; set; }

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
        public DateTime U_Last_Login {  get; set; } = DateTime.UtcNow;

        //Relationships
        public ICollection<UsersCredentialsModel> UsersCredentials { get; set; }
        public ICollection<UsersDietsModel> UsersDiets { get; set; }
        public ICollection<UsersExercisesModel> UsersExercises { get; set; }


    }
}