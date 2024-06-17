using ExerciseXData.Models;

namespace ExerciseXData.Interfaces
{
    public interface ICategoryService 
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Task AddAsync(Category category);
        Task<Category> UpdateAsync(int id, Category newCategory);
        Task DeleteAsync(int id);
    }
}
