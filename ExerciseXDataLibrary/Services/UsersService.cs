using ExerciseXDataLibrary.Repositories;
using ExerciseXDataLibrary.Data;

namespace ExerciseXDataLibrary.Services
{
    public class UsersService
    {
        private readonly UserDbContext _userDbContext;
        private readonly UsersRepository _usersRepository;

        public UsersService( UserDbContext userDbContext, UsersRepository usersRepository)
        {
            _userDbContext = userDbContext;
            _usersRepository = usersRepository;
        }

        public async Task<bool> RegisterUserAsync(string email, string userName, string password, string gender, int age, 
            double height, double weight, string goal, string lifeStyle1, string lifeStyle2, string lifeStyle3, string lifeStyle4, string lifeStyle5)
        {
            // Example: additional validation, or orchestration between repositories
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Email and Password are required");
            }

            // Register user through repository (with additional business logic as needed)
            return await _usersRepository.RegisterUserAsync(email, userName, password, gender, age, height, weight, 
                goal, lifeStyle1,  lifeStyle2, lifeStyle3, lifeStyle4, lifeStyle5);
        } 
    }
}