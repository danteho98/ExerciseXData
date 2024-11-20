using ExerciseXData.Data;
using ExerciseXData_ExerciseLibrary.Models;
using ExerciseXDataLibrary.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ExerciseXData_ExerciseLibrary.Services
{
    public class ExercisesService
    {
        private readonly ExercisesRepository _exercisesRepository;

        public ExercisesService(ExercisesRepository exercisesRepository)
        {
            _exercisesRepository = exercisesRepository;
        }

    //    public async Task<IEnumerable<ExercisesModel>> GetAllExercisesAsync() =>
    //        await _exercisesRepository.GetAllExercisesAsync();

    //    public async Task<ExercisesModel> GetExerciseByIdAsync(int id) =>
    //        await _exercisesRepository.GetExerciseByIdAsync(id);

    //    public async Task AddExerciseAsync(ExercisesModel exercise) =>
    //        await _exercisesRepository.AddExerciseAsync(exercise);

    //    public async Task<bool> UpdateExerciseAsync(int id, ExercisesModel updatedExercise)
    //    {
    //        return await _exercisesRepository.UpdateExerciseAsync(id, updatedExercise);
    //    }

    //    public async Task<bool> DeleteExerciseAsync(int id) =>
    //        await _exercisesRepository.DeleteExerciseAsync(id);
    }
}