using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseXData_SharedLibrary.Interface
{
  
    public interface IUserExercise
    {
        int ExercisePlanId { get; set; }
        string U_Id { get; set; }
    }

}
