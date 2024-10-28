using ExerciseXData.Data;
using ExerciseXData.Interfaces;
using ExerciseXData.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciseXData.Services
{
    public class ExercisesService

    {

        private readonly AppDbContext _context;

        public ExercisesService(AppDbContext context) 
        {
            _context = context;
        }

        public async Task AddAsync(ExercisesModel exercise)
        {
            await _context.Exercises.AddAsync(exercise);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Exercises.FirstOrDefaultAsync(n => n.E_Id == id);
            _context.Exercises.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ExercisesModel>> GetAllAsync()
        {
            var result = await _context.Exercises.ToListAsync();
            return result;
        }

        public async Task<ExercisesModel> GetByIdAsync(int id)
        {
            var result = await _context.Exercises.FirstOrDefaultAsync(n => n.E_Id == id);
            return result;
        }

        public async Task<ExercisesModel> UpdateAsync(int id, ExercisesModel newExercises)
        {
            _context.Update(newExercises);
            await _context.SaveChangesAsync();
            return newExercises;
        }

    }
}