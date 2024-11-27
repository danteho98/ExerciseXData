using ExerciseXData_SharedContracts.DataTransferObjects;

namespace ExerciseXData_SharedContracts.Interfaces
{
    public interface IUsersDietsRepository
    {
        Task<List<IUsersDiets>> GetUsersDietByUserIdAsync(int userId);
        Task AddUserDietAsync(IUsersDiets model);
        Task RemoveUserDietAsync(int userId, int dietId);
    }
}
