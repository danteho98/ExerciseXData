using ExerciseXData.Models;

namespace ExerciseXData.Interfaces
{
    public interface IUserService //: IEntityBaseRepository<> User
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task AddAsync(User user);
        Task<User> UpdateAsync(int id, User newUser);
        Task DeleteAsync(int id);
    }
}
