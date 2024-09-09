using System.ComponentModel.DataAnnotations;

namespace ExerciseXDataApi.Models.Data
{
    public class Users
    {
        public int U_Id { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }

        //[Required]
        [Display(Name = "Full Name")]/*This part allows programmer to put any name*/
        public string U_Name { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "Age")]
        public int Age { get; set; }

        [Display(Name = "Height (cm)")]
        public double Height { get; set; }

        [Display(Name = "Weight (kg)")]
        public double Weight { get; set; }

        [Display(Name = "Lifestyle Condition 1")]
        public string? Lifestyle_Condition_1 { get; set; }

        [Display(Name = "Lifestyle Condition 2")]
        public string? Lifestyle_Condition_2 { get; set; }

        [Display(Name = "Lifestyle Condition 3")]
        public string? Lifestyle_Condition_3 { get; set; }

        [Display(Name = "Lifestyle Condition 4")]
        public string? Lifestyle_Condition_4 { get; set; }

        [Display(Name = "Lifestyle Condition 5")]
        public string? Lifestyle_Condition_5 { get; set; }
        
    }
}
