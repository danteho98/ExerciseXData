using ExerciseXData_ExerciseLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseXData_ExerciseLibrary.Interface
{
    public interface IExerciseRepository
    {
        Task<IEnumerable<ExercisesModel>> GetAllExercisesAsync();
        Task<ExercisesModel> GetExerciseByIdAsync(int id);
        Task AddExerciseAsync(ExercisesModel exercise);
        Task UpdateExerciseAsync(ExercisesModel exercise);
        Task DeleteExerciseAsync(int id);
        Task<int> GetTotalExercisesAsync();
    }
}
