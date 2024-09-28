using ExerciseXData.Data;
using ExerciseXData.Interfaces;
using ExerciseXData.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciseXData.Interfaces
{
    
    public class CategoryService //: ICategoryService 
    {
        /*
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context) //: base(context) { }
        {
            _context = context;
        }

        public async Task AddAsync(Category category)
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

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var result = await _context.Categories.ToListAsync();
            return result;
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var result = await _context.Categories.FirstOrDefaultAsync(n => n.C_Id == id);
            return result;
        }

        public async Task<Category> UpdateAsync(int id, Category newCategory)
        {
            _context.Update(newCategory);
            await _context.SaveChangesAsync();
            return newCategory;
        }
        */
    }
}