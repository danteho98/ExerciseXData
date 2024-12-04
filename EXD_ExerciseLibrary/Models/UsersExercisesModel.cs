

using ExerciseXData_UserLibrary.Models;

namespace ExerciseXData_ExerciseLibrary.Models
{
    public class UsersExercisesModel 
    {
        public int UE_Id { get; set; }
        public string UserId { get; set; }
        public UsersModel User { get; set; }
        public int E_Id { get; set; }
        public ExercisesModel Exercise { get; set; }
        public int ExercisePlanId { get; set; }  // Exercise Plan Foreign Key
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Completed { get; set; }
        public DateTime UE_ModifiedDate { get; set; } = DateTime.UtcNow;

        //public UsersModel Users { get; set; }
        public ExercisesModel Exercises { get; set; }
       
    }
}
