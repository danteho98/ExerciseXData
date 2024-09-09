using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciseXData.Models
{
    public class Food
    {
        [Key]
        public int F_Id { get; set; }

        [Display(Name = "Food C_Image")]
        public string ? F_C_Image { get; set; }

        [Display(Name = "Food Name")]
        public string? F_Name { get; set; }

        [Display(Name = "Food Calorie in kcal (per 100 grams)")]
        public int ? F_Food_Calories { get; set; }

        //public date Modify_Date_ { get; set; }

        //Relationship
        public List<UserDiet> UserDiet { get; set; }

        //Diets
        [ForeignKey("D_Id")]
        public int D_Id { get; set; }
        public Diet Diet { get; set; }

        
    }
}
