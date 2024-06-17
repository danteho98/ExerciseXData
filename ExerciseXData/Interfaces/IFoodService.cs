using ExerciseXData.Models;

namespace ExerciseXData.Interfaces
{
    public interface IFoodService
    {
        Task<IEnumerable<Food>> GetAllAsync();
        Task<Food> GetByIdAsync(int id);
        Task AddAsync(Food food);
        Task<Food> UpdateAsync(int id, Food newFood);
        Task DeleteAsync(int id);
    }
}
