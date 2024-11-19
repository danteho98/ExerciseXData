
using System.ComponentModel;
using static ExerciseXDataLibrary.Models.UserGender;
using Microsoft.AspNetCore.Identity;


namespace ExerciseXData_DietLibrary.Models
{

    public class UsersModel : IdentityUser
    {
        
        public Gender U_Gender { get; set; }

        [DisplayName("Role")]
        public string U_Role { get; set; }

        [DisplayName ("Age")]
        public int U_Age { get; set; }

        [DisplayName("Height (cm)")]
        public double U_Height_CM { get; set; }

        [DisplayName("Weight (kg)")]
        public double U_Weight_KG { get; set; }

        [DisplayName("Goal")]
        public string U_Goal { get; set; }

        [DisplayName("Lifestyle Condition 1")]
        public string ? U_Lifestyle_Condition_1 { get; set; }

        [DisplayName("Lifestyle Condition 2")]
        public string ? U_Lifestyle_Condition_2 { get; set; }

        [DisplayName ("Lifestyle Condition 3")]
        public string ? U_Lifestyle_Condition_3 { get; set; }

        [DisplayName ("Lifestyle Condition 4")]
        public string ? U_Lifestyle_Condition_4 { get; set; }

        [DisplayName ("Lifestyle Condition 5")]
        public string ? U_Lifestyle_Condition_5 { get; set; }

        [DisplayName("Created Date")]
        public DateTime U_Created_Date { get; set; } = DateTime.UtcNow;

        [DisplayName("Last Login")]
        public DateTime U_Last_Login {  get; set; } = DateTime.UtcNow;

        //Relationships
      
        public ICollection<UsersDietsModel> UsersDiets { get; set; }
        public ICollection<UsersExercisesModel> UsersExercises { get; set; }


    }
}