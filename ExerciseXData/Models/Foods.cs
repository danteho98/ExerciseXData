using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciseXData.Models
{
    public class Foods
    {
        [Key]
        public int F_Id { get; set; }

        [DisplayName ("Food Image")]
        public string ? F_Image { get; set; }

        [Display(Name = "Food Name")]
        public string? F_Name { get; set; }

        [DisplayName ("Food Calorie in kcal")]
        public int ? F_Calories { get; set; }

        [DisplayName("Date Modified")]
        public DateTime F_Modified_Date { get; set; }

        //Relationship
        public List<DietsFoods>DietsFoods { get; set; }
        public List<UsersDiets> UsersDiets { get; set; }


        //Diets
        //[ForeignKey("D_Id")]
        //public int D_Id { get; set; }
        //public Diets Diets { get; set; }

    }
}
