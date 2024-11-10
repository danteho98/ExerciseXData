using ExerciseXDataLibrary.Repositories;
using ExerciseXDataLibrary.Data;
using static ExerciseXDataLibrary.Models.UsersModel;
using static ExerciseXDataLibrary.Models.UserGender;

namespace ExerciseXDataLibrary.Services
{
    public class UsersService
    {
        private readonly UserDbContext _userDbContext;
        private readonly UsersRepository _usersRepository;

        public UsersService(UserDbContext userDbContext, UsersRepository usersRepository)
        {
            _userDbContext = userDbContext;
            _usersRepository = usersRepository;
        }

        public async Task<bool> RegisterUserAsync(string email, string userName, string password, string gender, int age,
            double height, double weight, string goal, string lifeStyle1, string lifeStyle2, string lifeStyle3, string lifeStyle4, string lifeStyle5)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Email and Password are required");
            }

            if (!Enum.TryParse<Gender>(gender, out var parsedGender))
            {
                parsedGender = Gender.PreferNotToSay; // Default or fallback value if parsing fails
            }

            return await _usersRepository.RegisterUserAsync(
                email,
                userName,
                password,
                parsedGender,  // Pass the parsed enum here
                age,
                height,
                weight,
                goal,
                lifeStyle1,
                lifeStyle2,
                lifeStyle3,
                lifeStyle4,
                lifeStyle5);
        }

        public async Task<bool> LoginUserAsync(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Username and Password are required");
            }

            return await _usersRepository.LoginUserAsync(username, password);
        }
    }
}
