

using System.ComponentModel.DataAnnotations;

namespace ExerciseXData_DietLibrary.DataTransferObject
{
    public class DietDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string MealPlan { get; set; }

        [Range(1, 7)]
        public int DaysPerWeek { get; set; }

        public int Calories { get; set; } // in kcal
    }
}
