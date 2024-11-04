using ExerciseXData.Data;
using ExerciseXData.Interfaces;
using ExerciseXData.Models;
using ExerciseXDataLibrary.Data;
using Microsoft.EntityFrameworkCore;

namespace ExerciseXData.Services
{
    public class FoodsService
    {

        private readonly DietDbContext _dietContext;

        public FoodsService(DietDbContext foodsContext)
        {
            _dietContext = foodsContext;
        }

        public async Task AddAsync(FoodsModel foods)
        {
            await _dietContext.Foods.AddAsync(foods);
            await _dietContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _dietContext.Foods.FirstOrDefaultAsync(n => n.F_Id == id);
            _dietContext.Foods.Remove(result);
            await _dietContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<FoodsModel>> GetAllAsync()
        {
            var result = await _dietContext.Foods.ToListAsync();
            return result;
        }

        public async Task<FoodsModel> GetByIdAsync(int id)
        {
            var result = await _dietContext.Foods.FirstOrDefaultAsync(n => n.F_Id == id);
            return result;
        }

        public async Task<FoodsModel> UpdateAsync(int id, FoodsModel newFoods)
        {
            _dietContext.Update(newFoods);
            await _dietContext.SaveChangesAsync();
            return newFoods;
        }

    }
}
