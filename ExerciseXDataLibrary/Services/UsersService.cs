using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using ExerciseXData_UserLibrary.Repositories;
using ExerciseXData_UserLibrary.Models;
using static ExerciseXData_UserLibrary.Models.UsersModel;
using static ExerciseXData_UserLibrary.Models.UserGender;

namespace ExerciseXData_UserLibrary.Services
{
    public class UsersService
    {
        private readonly UsersRepository _usersRepository;
        private readonly UserManager<UsersModel> _userManager;
        private readonly SignInManager<UsersModel> _signInManager;
        private readonly ILogger<UsersService> _logger;

        public UsersService(
            UsersRepository usersRepository,
            UserManager<UsersModel> userManager,
            SignInManager<UsersModel> signInManager,
            ILogger<UsersService> logger)
        {
            _usersRepository = usersRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        public async Task<bool> RegisterUserAsync(
            string email,
            string userName,
            string password,
            Gender uGender,
            int uAge,
            double uHeightCm,
            double uWeightKg,
            string uGoal,
            string? uLifestyleCondition1 = null,
            string? uLifestyleCondition2 = null,
            string? uLifestyleCondition3 = null,
            string? uLifestyleCondition4 = null,
            string? uLifestyleCondition5 = null)
        {
            try
            {
                // Check if the email is already in use
                var existingUser = await _userManager.FindByEmailAsync(email);
                if (existingUser != null)
                {
                    _logger.LogWarning("Registration failed: Email already in use - {Email}", email);
                    return false;
                }

                // Create a new UsersModel instance
                var newUser = new UsersModel
                {
                    Email = email,
                    UserName = userName,
                    U_UserGender = uGender,
                    U_Role = "NormalUser", // Default role for new users
                    U_Age = uAge,
                    U_Height_CM = uHeightCm,
                    U_Weight_KG = uWeightKg,
                    U_Goal = uGoal,
                    U_Lifestyle_Condition_1 = uLifestyleCondition1,
                    U_Lifestyle_Condition_2 = uLifestyleCondition2,
                    U_Lifestyle_Condition_3 = uLifestyleCondition3,
                    U_Lifestyle_Condition_4 = uLifestyleCondition4,
                    U_Lifestyle_Condition_5 = uLifestyleCondition5
                };

                // Use Identity to create the user
                var identityResult = await _userManager.CreateAsync(newUser, password);

                if (identityResult.Succeeded)
                {
                    _logger.LogInformation("User registered successfully with email: {Email}", email);
                    return true;
                }

                foreach (var error in identityResult.Errors)
                {
                    _logger.LogError("Registration error: {Error}", error.Description);
                }

                return false;
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
                // Attempt to find the user by email
                var user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    _logger.LogWarning("Login failed: User not found with email: {Email}", email);
                    return false;
                }

                // Use SignInManager to sign in the user
                var signInResult = await _signInManager.PasswordSignInAsync(user, password, isPersistent: false, lockoutOnFailure: false);

                if (signInResult.Succeeded)
                {
                    _logger.LogInformation("User logged in successfully with email: {Email}", email);
                    return true;
                }

                _logger.LogWarning("Login failed for email: {Email}", email);
                return false;
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
                var user = await _usersRepository.GetUserByEmailAsync(email);

                if (user == null)
                {
                    _logger.LogWarning("User not found with email: {Email}", email);
                }

                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving user with email: {Email}", email);
                return null;
            }
        }
    }
}
