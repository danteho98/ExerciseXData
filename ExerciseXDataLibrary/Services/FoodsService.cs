using ExerciseXData.Data;
using ExerciseXData.Interfaces;
using ExerciseXData.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciseXData.Services
{
    public class FoodsService
    {

        private readonly AppDbContext _context;

        public FoodsService(AppDbContext foodscontext)
        {
            _context = foodscontext;
        }

        public async Task AddAsync(FoodsModel foods)
        {
            await _context.Foods.AddAsync(foods);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Foods.FirstOrDefaultAsync(n => n.F_Id == id);
            _context.Foods.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<FoodsModel>> GetAllAsync()
        {
            var result = await _context.Foods.ToListAsync();
            return result;
        }

        public async Task<FoodsModel> GetByIdAsync(int id)
        {
            var result = await _context.Foods.FirstOrDefaultAsync(n => n.F_Id == id);
            return result;
        }

        public async Task<FoodsModel> UpdateAsync(int id, FoodsModel newFoods)
        {
            _context.Update(newFoods);
            await _context.SaveChangesAsync();
            return newFoods;
        }

    }
}
