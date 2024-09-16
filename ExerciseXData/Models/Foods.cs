using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciseXData.Models
{
    public class Foods
    {
        [Key]
        public int F_Id { get; set; }

        [Display(Name = "Food C_Image")]
        public string ? F_Image { get; set; }

        [Display(Name = "Food Name")]
        public string? F_Name { get; set; }

        [DisplayName ("Food Calorie in kcal")]
        public int ? F_Calories { get; set; }

        [DisplayName("Date Modified")]
        public DateTime F_Modified_Date { get; set; }

        //Relationship
        public List<UsersDiets> UserDiet { get; set; }

        //Diets
        [ForeignKey("D_Id")]
        public int D_Id { get; set; }
        public Diets Diet { get; set; }

        
    }
}
