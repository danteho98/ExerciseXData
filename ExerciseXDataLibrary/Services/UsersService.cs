
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using ExerciseXData_UserLibrary.Data;
using ExerciseXData_UserLibrary.Repositories;
using ExerciseXData_UserLibrary.Models;
using static ExerciseXData_UserLibrary.Models.UserGender;

namespace ExerciseXDataLibrary.Services
{
    public class UsersService
    {
        private readonly UserDbContext _userDbContext;
        private readonly UsersRepository _usersRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<UsersRepository> _logger;

        public UsersService(
            UserDbContext userDbContext,
            UsersRepository usersRepository,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<UsersRepository> logger)
        {
            _userDbContext = userDbContext;
            _usersRepository = usersRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        public async Task<bool> RegisterUserAsync(
            string email, string userName, string password, Gender gender, int age,
            double height, double weight, string goal, string lifeStyle1, string lifeStyle2, string lifeStyle3, string lifeStyle4, string lifeStyle5)
        {
            try
            {
                // Validate inputs if needed
                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                {
                    _logger.LogWarning("Registration failed: Invalid email or password.");
                    return false;
                }

                // Check if the email is already in use
                var existingUser = await _userManager.FindByEmailAsync(email);
                if (existingUser != null)
                {
                    _logger.LogWarning("Registration failed: Email already in use - {Email}", email);
                    return false;
                }

                // Delegate to the repository to handle registration
                var result = await _usersRepository.RegisterUserAsync(
                    email, userName, password, gender, age, height, weight,
                    goal, lifeStyle1, lifeStyle2, lifeStyle3, lifeStyle4, lifeStyle5);

                if (result)
                {
                    _logger.LogInformation("User successfully registered with email: {Email}", email);
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during user registration for email: {Email}", email);
                return false;
            }
        }

      
     

        }
    }

