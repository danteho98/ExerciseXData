using ExerciseXData.Data;
using ExerciseXData.Interfaces;
using ExerciseXData.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciseXData.Interfaces
{
    
    public class CategoriesService
    {

        private readonly AppDbContext _context;

        public CategoriesService(AppDbContext context) 
        { 
            _context = context;
        }

        public async Task AddAsync(CategoriesModel category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Categories.FirstOrDefaultAsync(n => n.C_Id == id);
            _context.Categories.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoriesModel>> GetAllAsync()
        {
            var result = await _context.Categories.ToListAsync();
            return result;
        }

        public async Task<CategoriesModel> GetByIdAsync(int id)
        {
            var result = await _context.Categories.FirstOrDefaultAsync(n => n.C_Id == id);
            return result;
        }

        public async Task<CategoriesModel> UpdateAsync(int id, CategoriesModel newCategories)
        {
            _context.Update(newCategories);
            await _context.SaveChangesAsync();
            return newCategories;
        }

    }
}