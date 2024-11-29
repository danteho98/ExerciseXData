using ExerciseXData_ExerciseLibrary.Models;
using ExerciseXData_ExerciseLibrary.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExerciseXData_ExerciseLibrary.Data;


namespace ExerciseXData_ExerciseLibrary.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ExerciseDbContext _exerciseDbContext;

        public CategoryRepository(ExerciseDbContext exerciseDbContext)
        {
            _exerciseDbContext = exerciseDbContext;
        }

        public async Task AddAsync(CategoriesModel model)
        {
            await _exerciseDbContext.Set<CategoriesModel>().AddAsync(model);
        }

        public async Task<IEnumerable<CategoriesModel>> GetAllAsync()
        {
            return await _exerciseDbContext.Set<CategoriesModel>().ToListAsync();
        }

        public async Task<CategoriesModel> GetByIdAsync(int c_Id)
        {
            return await _exerciseDbContext.Set<CategoriesModel>().FindAsync(c_Id);
        }

        public async Task SaveChangesAsync()
        {
            await _exerciseDbContext.SaveChangesAsync();
        }

        public void UpdateAsync(CategoriesModel model) // Implement Update
        {
            _exerciseDbContext.Set<CategoriesModel>().Update(model); // Mark the entity as modified
        }

        public void DeleteAsync(CategoriesModel model)  // Implement Delete
        {
            _exerciseDbContext.Set<CategoriesModel>().Remove(model); // Remove the entity
        }
    }

}
