using System;
using System.Threading.Tasks;
using ExerciseXData_UserLibrary.DataTransferObject;
using ExerciseXData_UserLibrary.Models;
using ExerciseXData_UserLibrary.Repositories;
using Microsoft.Extensions.Logging;

namespace ExerciseXData_UserLibrary.Services
{
    public class UsersService
    {
        private readonly UsersRepository _userRepository;
        private readonly ILogger<UsersService> _logger;

        public UsersService(UsersRepository userRepository, ILogger<UsersService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        /// <summary>
        /// Registers a new user with business logic validation.
        /// </summary>
        public async Task<bool> RegisterUserAsync(RegisterUserDto dto)
        {
            try
            {
                // Validate email and username uniqueness
                if (await _userRepository.UserExistsAsync(dto.Email))
                {
                    _logger.LogWarning("User registration failed: Email already exists.");
                    throw new Exception("Email is already in use.");
                }

                if (await _userRepository.UserExistsAsync(dto.UserName))
                {
                    _logger.LogWarning("User registration failed: Username already exists.");
                    throw new Exception("Username is already in use.");
                }

                // Validate required fields
                if (dto.Age < 1)
                {
                    throw new Exception("Age must be greater than 0.");
                }

                if (dto.Height <= 0 || dto.Weight <= 0)
                {
                    throw new Exception("Height and Weight must be positive values.");
                }

                // Map DTO to domain model
                var user = new UsersModel
                {
                    Email = dto.Email,
                    UserName = dto.UserName,
                    U_UserGender = dto.Gender,
                    U_Age = dto.Age,
                    U_Height_CM = dto.Height,
                    U_Weight_KG = dto.Weight,
                    U_Goal = dto.Goal,
                    U_Lifestyle_Condition_1 = dto.LifestyleCondition1,
                    U_Lifestyle_Condition_2 = dto.LifestyleCondition2,
                    U_Lifestyle_Condition_3 = dto.LifestyleCondition3,
                    U_Lifestyle_Condition_4 = dto.LifestyleCondition4,
                    U_Lifestyle_Condition_5 = dto.LifestyleCondition5,
                    U_Created_Date = DateTime.UtcNow
                };

                // Delegate user creation to the repository
                bool isCreated = await _userRepository.CreateAsync(user, dto.Password);

                if (isCreated)
                {
                    _logger.LogInformation("User registered successfully: {Email}", dto.Email);
                    return true;
                }

                _logger.LogWarning("User registration failed for email: {Email}", dto.Email);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during user registration.");
                throw; // Re-throw exception to the controller
            }
        }

        /// <summary>
        /// Authenticates a user with their credentials.
        /// </summary>
        public async Task<bool> LoginAsync(string email, string password)
        {
            try
            {
                var isAuthenticated = await _userRepository.AuthenticateAsync(email, password);
                if (isAuthenticated)
                {
                    _logger.LogInformation("User logged in successfully: {Email}", email);
                    return true;
                }

                _logger.LogWarning("Invalid login attempt for email: {Email}", email);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during login for email: {Email}", email);
                throw; // Re-throw to the controller
            }
        }

        /// <summary>
        /// Logs the user out of the application.
        /// </summary>
        public async Task SignOutAsync()
        {
            try
            {
                await _userRepository.SignOutAsync();
                _logger.LogInformation("User signed out successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during user sign out.");
                throw; // Re-throw to the controller
            }
        }

        /// <summary>
        /// Resets the password for a user.
        /// </summary>
        public async Task<bool> ResetPasswordAsync(string email, string newPassword, string token)
        {
            try
            {
                var result = await _userRepository.ResetPasswordAsync(email, newPassword, token);
                if (result)
                {
                    _logger.LogInformation("Password reset successfully for email: {Email}", email);
                    return true;
                }

                _logger.LogWarning("Password reset failed for email: {Email}", email);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during password reset for email: {Email}", email);
                throw; // Re-throw to the controller
            }
        }

        /// <summary>
        /// Changes the password for a user.
        /// </summary>
        public async Task<bool> ChangePasswordAsync(string userId, string currentPassword, string newPassword)
        {
            try
            {
                var result = await _userRepository.ChangePasswordAsync(userId, currentPassword, newPassword);
                if (result)
                {
                    _logger.LogInformation("Password changed successfully for user ID: {UserId}", userId);
                    return true;
                }

                _logger.LogWarning("Password change failed for user ID: {UserId}", userId);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during password change for user ID: {UserId}", userId);
                throw; // Re-throw to the controller
            }
        }




    }
}