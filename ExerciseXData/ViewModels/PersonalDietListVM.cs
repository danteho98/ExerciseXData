using System.ComponentModel;

namespace ExerciseXData.ViewModels
{
    public class PersonalDietListVM
    {
        [DisplayName("Diet Name")]
        public string DietName { get; set; }

        [DisplayName("Food Name")]
        public string FoodName { get; set; }

        public int Quantity { get; set; }

        [DisplayName("Food Calorie")]
        public int FoodCalories { get; set; }

        [DisplayName("Total Food Calories")]
        public int TotalFoodCalories { get; set; }
    }
}
