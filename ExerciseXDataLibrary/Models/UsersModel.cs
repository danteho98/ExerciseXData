
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ExerciseXData_UserLibrary.Models
{

    public class UsersModel : IdentityUser
    {
        public UserGenderModel.Gender U_UserGender { get; set; }

        [DisplayName ("Age")]
        public int U_Age { get; set; }

        [DisplayName("Height (cm)")]
        public double U_Height_CM { get; set; }

        [DisplayName("Weight (kg)")]
        [Range(0, 500, ErrorMessage = "Weight must be between 0 and 500.")]
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

     
    }
}