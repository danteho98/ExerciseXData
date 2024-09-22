using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciseXData.Models
{
    public class Users
    {
        [Key]
        public int U_Id { get; set; }

        [DisplayName ("Email")]
        public string ? Email { get; set; }

        //[Display(Name = "Password")]
        //public string ? Password { get; set; }
        
        //[Required]
        [DisplayName ("Full Name")]/*This part allows programmer to put any name*/
        public string ? U_Name { get; set; }

        [DisplayName ("Gender")]
        public string ? Gender { get; set; }

        [DisplayName ("Age")]
        public int ? Age { get; set; }

        [DisplayName("Height (cm)")]
        public double ? Height { get; set; }

        [DisplayName("Weight (kg)")]
        public double ? Weight { get; set; }

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

        //Relationships
        public List<UsersDiets> UsersDiets { get; set; }
        public ICollection<UsersExercises> UsersExercises { get; set; }


    }
}