using ExerciseXDataLibrary.Repositories;
using ExerciseXDataLibrary.Data;
using static ExerciseXDataLibrary.Models.UsersModel;
using static ExerciseXDataLibrary.Models.UserGender;
using ExerciseXDataLibrary.DataTransferObject;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ExerciseXDataLibrary.Models;

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

        public async Task<bool> LoginUserAsync(string email, string password)
        {
            try
            {
                // Delegate to the repository to handle login
                var result = await _usersRepository.LoginUserAsync(email, password);

                if (result)
                {
                    _logger.LogInformation("User login successful for email: {Email}", email);
                }
                else
                {
                    _logger.LogWarning("User login failed for email: {Email}", email);
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during user login for email: {Email}", email);
                return false;
            }
        }

        public async Task<UsersModel?> GetUserByEmailAsync(string email)
        {
            try
            {
                // Delegate to the repository to retrieve user details
                var user = await _usersRepository.GetUserByEmailAsync(email);

                if (user != null)
                {
                    _logger.LogInformation("Retrieved user with email: {Email}", email);
                }
                else
                {
                    _logger.LogWarning("No user found with email: {Email}", email);
                }

                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving user by email: {Email}", email);
                return null;
            }
        }

        public async Task<(UsersModel?, IdentityUser?)> GetUserAndIdentityAsync(string email)
        {
            try
            {
                // Retrieve both the application user and identity user
                var result = await _usersRepository.GetUserAndIdentityAsync(email);

                if (result.Item1 != null && result.Item2 != null)
                {
                    _logger.LogInformation("Retrieved user and identity for email: {Email}", email);
                }
                else
                {
                    _logger.LogWarning("Could not retrieve user or identity for email: {Email}", email);
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving user and identity by email: {Email}", email);
                return (null, null);
            }

        }
    }
}
