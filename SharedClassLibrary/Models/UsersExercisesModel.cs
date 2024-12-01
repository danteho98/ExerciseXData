

using ExerciseXData_ExerciseLibrary.Models;
using ExerciseXData_UserLibrary.Models;

namespace ExerciseXData_SharedLibrary.Models
{
    public class UsersExercisesModel
    {
        public int UE_Id { get; set; }
        public string U_Id { get; set; }
        public int E_Id { get; set; }
        public int Repetition { get; set; }
        public int Sets { get; set; }
        public int Duration_sec { get; set; }
        public DateTime UE_Modified_Date { get; set; } = DateTime.UtcNow;

        public UsersModel Users { get; set; }
        public ExercisesModel Exercises { get; set; }
    }
}
