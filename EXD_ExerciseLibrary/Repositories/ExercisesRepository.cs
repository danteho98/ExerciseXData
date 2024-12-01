
using ExerciseXData_ExerciseLibrary.Data;
using ExerciseXData_ExerciseLibrary.Interface;
using ExerciseXData_ExerciseLibrary.Models;
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

        public async Task<IEnumerable<ExercisesModel>> GetAllExercisesAsync()
        {
            return await _exerciseDbContext.Exercises
                .Include(e => e.CategoriesC_Id) // Include the Category for each Exercise
                .ToListAsync();
        }

        public async Task<ExercisesModel> GetExerciseByIdAsync(int id)
        {
            return await _exerciseDbContext.Exercises
                .Include(e => e.CategoriesC_Id) // Include the Category for this Exercise
                .FirstOrDefaultAsync(e => e.E_Id == id);
        }

        public async Task AddExerciseAsync(ExercisesModel exercise)
        {
            _exerciseDbContext.Exercises.Add(exercise);
            await _exerciseDbContext.SaveChangesAsync();
        }

        public async Task UpdateExerciseAsync(ExercisesModel exercise)
        {
            _exerciseDbContext.Exercises.Update(exercise);
            await _exerciseDbContext.SaveChangesAsync();
        }

        public async Task DeleteExerciseAsync(int id)
        {
            var exercise = await _exerciseDbContext.Exercises.FindAsync(id);
            if (exercise != null)
            {
                _exerciseDbContext.Exercises.Remove(exercise);
                await _exerciseDbContext.SaveChangesAsync();
            }
        }

        public async Task<int> GetTotalExercisesAsync()
        {
            return await _exerciseDbContext.Exercises.CountAsync();
        }
    }
}
