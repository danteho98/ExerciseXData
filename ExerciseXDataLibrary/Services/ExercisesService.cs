using ExerciseXData.Data;
using ExerciseXData.Interfaces;
using ExerciseXData.Models;
using ExerciseXDataLibrary.Data;
using Microsoft.EntityFrameworkCore;

namespace ExerciseXData.Services
{
    public class ExercisesService
    {
        private readonly ExerciseDbContext _exerciseDbContext;

        public ExercisesService(ExerciseDbContext exerciseDbContext) 
        {
            _exerciseDbContext = exerciseDbContext;
        }

        public async Task AddAsync(ExercisesModel exercise)
        {
            await _exerciseDbContext.Exercises.AddAsync(exercise);
            await _exerciseDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _exerciseDbContext.Exercises.FirstOrDefaultAsync(n => n.E_Id == id);
            _exerciseDbContext.Exercises.Remove(result);
            await _exerciseDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ExercisesModel>> GetAllAsync()
        {
            var result = await _exerciseDbContext.Exercises.ToListAsync();
            return result;
        }

        public async Task<ExercisesModel> GetByIdAsync(int id)
        {
            var result = await _exerciseDbContext.Exercises.FirstOrDefaultAsync(n => n.E_Id == id);
            return result;
        }

        public async Task<ExercisesModel> UpdateAsync(int id, ExercisesModel newExercises)
        {
            _exerciseDbContext.Update(newExercises);
            await _exerciseDbContext.SaveChangesAsync();
            return newExercises;
        }

    }
}