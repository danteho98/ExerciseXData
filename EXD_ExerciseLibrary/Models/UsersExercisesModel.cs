using ExerciseXData_UserLibrary.Models;

namespace ExerciseXData_ExerciseLibrary.Models
{
    public class UsersExercisesModel
    {
        public int UE_Id { get; set; }
        public string U_Id { get; set; }
        public int E_Id { get; set; }
        public int StartDate { get; set; }
        public int EndDate { get; set; }
        public DateTime Completed { get; set; } = DateTime.UtcNow;

        public UsersModel Users { get; set; }
        public ExercisesModel Exercises { get; set; }
    }
}
