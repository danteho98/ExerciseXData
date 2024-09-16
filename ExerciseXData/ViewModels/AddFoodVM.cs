using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExerciseXData.ViewModels
{
    public class AddFoodVM
    {
        [Display(Name = "Food Name")]
        public string F_Name { get; set; }

        [Display(Name = "Food Calorie in kcal (per 1 gram)")]
        public int F_Calories { get; set; }

        [Display(Name = "Quantity")]
        public int F_Quantity { get; set; }

        [Display(Name = "Date Modify")]
        public DateTime F_Modify_Date { get; set; } = DateTime.Now;
    }
}
