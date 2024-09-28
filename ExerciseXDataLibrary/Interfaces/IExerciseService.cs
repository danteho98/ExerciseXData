using ExerciseXData.Models;

namespace ExerciseXData.Interfaces
{
    public interface IExercisesService 
    {
        Task<List<Exercises>> GetAllAsync();
        Task<Exercises> GetByIdAsync(int id);
        Task AddAsync(Exercises exercise);
        Task<Exercises> UpdateAsync(int id, Exercises newExercises);
        Task DeleteAsync(int id);
    }
}
