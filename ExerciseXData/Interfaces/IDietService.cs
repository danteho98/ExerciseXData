using ExerciseXData.Models;

namespace ExerciseXData.Interfaces
{
    public interface IDietService //: IEntityBaseRepository<>  Diet
    {
        Task<IEnumerable<Diet>> GetAllAsync();
        Task<Diet> GetByIdAsync(int id);
        Task AddAsync(Diet Diet);
        Task<Diet> UpdateAsync(int id, Diet newDiet);
        Task DeleteAsync(int id);
    }
}
