using ExerciseXData.Data;
using ExerciseXData.Interfaces;
using ExerciseXData.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciseXData.Services
{
    public class DietService : IDietService // EntityBaseRepository<Diet>
    {
        //public DietService(AppDbContext context) : base(context) {}
        private readonly AppDbContext _context;

        public DietService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Diet diet)
        {
            await _context.Diets.AddAsync(diet);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Diets.FirstOrDefaultAsync(n => n.D_Id == id);
            _context.Diets.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Diet>> GetAllAsync()
        {
            var result = await _context.Diets.ToListAsync();
            return result;
        }

        public async Task<Diet> GetByIdAsync(int id)
        {
            var result = await _context.Diets.FirstOrDefaultAsync(n => n.D_Id == id);
            return result;
        }

        public async Task<Diet> UpdateAsync(int id, Diet newDiet)
        {
            _context.Update(newDiet);
            await _context.SaveChangesAsync();
            return newDiet;
        }
    }
}
