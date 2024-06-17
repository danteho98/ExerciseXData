using ExerciseXData.Data;
using ExerciseXData.Interfaces;
using ExerciseXData.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciseXData.Services
{
    public class FoodService: IFoodService
    {
        private readonly AppDbContext _context;

        public FoodService(AppDbContext foodcontext)
        {
            _context = foodcontext;
        }

        public async Task AddAsync(Food food)
        {
            await _context.Foods.AddAsync(food);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Foods.FirstOrDefaultAsync(n => n.F_Id == id);
            _context.Foods.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Food>> GetAllAsync()
        {
            var result = await _context.Foods.ToListAsync();
            return result;
        }

        public async Task<Food> GetByIdAsync(int id)
        {
            var result = await _context.Foods.FirstOrDefaultAsync(n => n.F_Id == id);
            return result;
        }

        public async Task<Food> UpdateAsync(int id, Food newFood)
        {
            _context.Update(newFood);
            await _context.SaveChangesAsync();
            return newFood;
        }
    }
}
