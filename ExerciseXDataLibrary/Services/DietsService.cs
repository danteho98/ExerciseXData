using ExerciseXData.Data;
using ExerciseXData.Interfaces;
using ExerciseXData.Models;
using ExerciseXDataLibrary.Data;
using Microsoft.EntityFrameworkCore;

namespace ExerciseXData.Services
{
    public class DietsService
    {
        private readonly DietDbContext _dietDbContext;

        public DietsService(DietDbContext dietDbContext)
        {
            _dietDbContext = dietDbContext;
        }

        public async Task AddAsync(DietsModel diet)
        {
            await _dietDbContext.Diets.AddAsync(diet);
            await _dietDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _dietDbContext.Diets.FirstOrDefaultAsync(n => n.D_Id == id);
            _dietDbContext.Diets.Remove(result);
            await _dietDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<DietsModel>> GetAllAsync()
        {
            var result = await _dietDbContext.Diets.ToListAsync();
            return result;
        }

        public async Task<DietsModel> GetByIdAsync(int id)
        {
            var result = await _dietDbContext.Diets.FirstOrDefaultAsync(n => n.D_Id == id);
            return result;
        }

        public async Task<DietsModel> UpdateAsync(int id, DietsModel newDiets)
        {
            _dietDbContext.Update(newDiets);
            await _dietDbContext.SaveChangesAsync();
            return newDiets;
        }

    }
}
