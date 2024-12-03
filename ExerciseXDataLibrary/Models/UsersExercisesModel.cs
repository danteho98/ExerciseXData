

using ExerciseXData_ExerciseLibrary.Models;

namespace ExerciseXData_UserLibrary.Models
{
    public class UsersExercisesModel 
    {
        public int UE_Id { get; set; }
        public string U_Id { get; set; }
        public int E_Id { get; set; }
        public int ExercisePlanId { get; set; }  // Exercise Plan Foreign Key
        public int StartDate { get; set; }
        public int EndDate { get; set; }
        public DateTime Completed { get; set; } = DateTime.UtcNow;

        //public UsersModel Users { get; set; }
        public ExercisesModel Exercises { get; set; }
       
    }
}
