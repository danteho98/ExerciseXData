
using ExerciseXData_ExerciseLibrary.Data;

using ExerciseXData_SharedContracts.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace ExerciseXData_ExerciseLibrary.Repositories
{
    public class ExercisesRepository : IExerciseRepository
    {
        private readonly ExerciseDbContext _exerciseDbContext;

        public ExercisesRepository(ExerciseDbContext exerciseDbContext)
        {
            _exerciseDbContext = exerciseDbContext;
        }

        public async Task<int> GetTotalExercisesAsync()
        {
            return await _exerciseDbContext.Exercises.CountAsync();
        }

    }
}
