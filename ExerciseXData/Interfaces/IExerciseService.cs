using ExerciseXData.Models;

namespace ExerciseXData.Interfaces
{
    public interface IExerciseService 
    {
        Task<IEnumerable<Exercise>> GetAllAsync();
        Task<Exercise> GetByIdAsync(int id);
        Task AddAsync(Exercise exercise);
        Task<Exercise> UpdateAsync(int id, Exercise newExercise);
        Task DeleteAsync(int id);
    }
}
