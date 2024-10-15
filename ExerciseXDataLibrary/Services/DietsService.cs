using ExerciseXData.Data;
using ExerciseXData.Interfaces;
using ExerciseXData.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciseXData.Services
{
    public class DietsService
    {
        private readonly AppDbContext _context;

        public DietsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Diets diet)
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

        public async Task<IEnumerable<Diets>> GetAllAsync()
        {
            var result = await _context.Diets.ToListAsync();
            return result;
        }

        public async Task<Diets> GetByIdAsync(int id)
        {
            var result = await _context.Diets.FirstOrDefaultAsync(n => n.D_Id == id);
            return result;
        }

        public async Task<Diets> UpdateAsync(int id, Diets newDiets)
        {
            _context.Update(newDiets);
            await _context.SaveChangesAsync();
            return newDiets;
        }

    }
}
