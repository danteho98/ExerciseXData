using ExerciseXData.Data;

using ExerciseXData_ExerciseLibrary.Data;
using ExerciseXData_ExerciseLibrary.Models;

using Microsoft.EntityFrameworkCore;

namespace ExerciseXDataLibrary.Services
{
    
    public class CategoriesService
    {

        private readonly ExerciseDbContext _categoryContext;

        public CategoriesService(ExerciseDbContext categoryContext) 
        { 
            _categoryContext = categoryContext;
        }

        //public async Task AddAsync(CategoriesModel category)
        //{
        //    await _categoryContext.Categories.AddAsync(category);
        //    await _categoryContext.SaveChangesAsync();
        //}

        //public async Task DeleteAsync(int id)
        //{
        //    var result = await _categoryContext.Categories.FirstOrDefaultAsync(n => n.C_Id == id);
        //    _categoryContext.Categories.Remove(result);
        //    await _categoryContext.SaveChangesAsync();
        //}

        //public async Task<IEnumerable<CategoriesModel>> GetAllAsync()
        //{
        //    var result = await _categoryContext.Categories.ToListAsync();
        //    return result;
        //}

        //public async Task<CategoriesModel> GetByIdAsync(int id)
        //{
        //    var result = await _categoryContext.Categories.FirstOrDefaultAsync(n => n.C_Id == id);
        //    return result;
        //}

        //public async Task<CategoriesModel> UpdateAsync(int id, CategoriesModel newCategories)
        //{
        //    _categoryContext.Update(newCategories);
        //    await _categoryContext.SaveChangesAsync();
        //    return newCategories;
        //}

    }
}