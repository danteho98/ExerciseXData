using ExerciseXData_ExerciseLibrary.Interface;
using ExerciseXData_ExerciseLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciseXData_ExerciseLibrary.Services
{
    public class ExercisesService : IExercisesService
    {
        private readonly IExerciseRepository _repository;

        public ExercisesService(IExerciseRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ExercisesModel>> GetAllExercisesAsync()
        {
            return await _repository.GetAllExercisesAsync();
        }

        public async Task<ExercisesModel> GetExerciseByIdAsync(int id)
        {
            return await _repository.GetExerciseByIdAsync(id);
        }

        public async Task AddExerciseAsync(ExercisesModel exercise)
        {
            await _repository.AddExerciseAsync(exercise);
        }

        public async Task UpdateExerciseAsync(ExercisesModel exercise)
        {
            await _repository.UpdateExerciseAsync(exercise);
        }

        public async Task DeleteExerciseAsync(int id)
        {
            await _repository.DeleteExerciseAsync(id);
        }

        //public async Task<List<ExercisePlanDto>> GetUserExercisePlansAsync(string userId)
        //{
        //    var userExercisePlans = await _repository.GetUserExercisePlansAsync(userId);

        //    // Mapping data from UsersExercisesModel to ExercisePlanDto
        //    return userExercisePlans.Select(ue => new ExercisePlanDto
        //    {
        //        Name = ue.ExercisePlanDto.Name,
        //        StartDate = ue.ExercisePlan.StartDate,
        //        EndDate = ue.ExercisePlan.EndDate
        //    }).ToList();
        //}

    }
}