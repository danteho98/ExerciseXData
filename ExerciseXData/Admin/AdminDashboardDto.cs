using ExerciseXData_ExerciseLibrary.Models;

namespace ExerciseXData.Admin
{
    public class AdminDashboardDto
    {
        public int categoryId { get; set; } // Add this property to hold categoryId
        public List<ExercisesModel> Exercises { get; set; }
        public int TotalUsers { get; set; }
        public int TotalExercises { get; set; }
        public int TotalDiets { get; set; }
    }
}