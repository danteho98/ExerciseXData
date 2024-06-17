using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciseXData.Models
{
    public class UserDiet
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Food Name")]
        public string Food_Name { get; set; }

        [Required]
        [Display(Name = "Food Quantity")]
        public int Food_Quantity { get; set; }

        [Required]
        [Display(Name = "Food Calorie in kcal (per 100 grams)")]
        public int Food_Calories { get; set; }

        [Display(Name = "Total Calories")]
        public int ? Total_Calories { get; set; }

        [Display(Name = "Modify Date")]
        public DateTime ModifyDate { get; set; } = DateTime.Now;

        //Relationships
        
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; }
        
        [ForeignKey("DietId")]
        public int DietId { get; set; }
        public Diet Diet { get; set; }
        
        [ForeignKey("FoodId")]
        public int FoodId { get; set; }
        public Food Food { get; set; }
        
    }
}
