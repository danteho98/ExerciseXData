using ExerciseXData.Models;

namespace ExerciseXData.Interfaces
{
    public interface IExerciseService 
    {
        Task<IEnumerable<Exercises>> GetAllAsync();
        Task<Exercises> GetByIdAsync(int id);
        Task AddAsync(Exercises exercise);
        Task<Exercises> UpdateAsync(int id, Exercises newExercise);
        Task DeleteAsync(int id);
    }
}
