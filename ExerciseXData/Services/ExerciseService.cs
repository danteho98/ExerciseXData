using ExerciseXData.Data;
using ExerciseXData.Interfaces;
using ExerciseXData.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciseXData.Services
{
    public class ExerciseService : IExerciseService //: EntityBaseRepository<Exercise>, 
    {
        private readonly AppDbContext _context;

        public ExerciseService(AppDbContext context) //: base(context) { }
        {
            _context = context;
        }

        public async Task AddAsync(Exercise exercise)
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

        public async Task<IEnumerable<Exercise>> GetAllAsync()
        {
            var result = await _context.Exercises.ToListAsync();
            return result;
        }

        public async Task<Exercise> GetByIdAsync(int id)
        {
            var result = await _context.Exercises.FirstOrDefaultAsync(n => n.E_Id == id);
            return result;
        }

        public async Task<Exercise> UpdateAsync(int id, Exercise newExercise)
        {
            _context.Update(newExercise);
            await _context.SaveChangesAsync();
            return newExercise;
        }
    }
}
