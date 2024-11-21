using System;
using System.Linq;
using System.Threading.Tasks;
using ExerciseXData_UserLibrary.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static ExerciseXData_UserLibrary.Models.UserGender;

namespace ExerciseXData_UserLibrary.Repositories
{
    public class UsersRepository
    {
        private readonly UserManager<UsersModel> _userManager;
        private readonly ILogger<UsersRepository> _logger;

        public UsersRepository(UserManager<UsersModel> userManager, ILogger<UsersRepository> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        /// <summary>
        /// Registers a new user with custom fields.
        /// </summary>
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
                var user = new UsersModel
                {
                    Email = email,
                    UserName = userName,
                    U_UserGender = uGender,
                    U_Age = uAge,
                    U_Height_CM = uHeightCm,
                    U_Weight_KG = uWeightKg,
                    U_Goal = uGoal,
                    U_Lifestyle_Condition_1 = uLifestyleCondition1,
                    U_Lifestyle_Condition_2 = uLifestyleCondition2,
                    U_Lifestyle_Condition_3 = uLifestyleCondition3,
                    U_Lifestyle_Condition_4 = uLifestyleCondition4,
                    U_Lifestyle_Condition_5 = uLifestyleCondition5,
                    U_Created_Date = DateTime.UtcNow,
                    U_Last_Login = DateTime.UtcNow,
                    U_Role = "User" // Default role
                };

                var result = await _userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User registered successfully: {Email}", email);
                    return true;
                }
                else
                {
                    _logger.LogWarning("User registration failed: {Errors}", string.Join(", ", result.Errors.Select(e => e.Description)));
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while registering a user.");
                return false;
            }
        }

        public async Task<UsersModel?> GetUserByEmailAsync(string email)
        {
            try
            {
                // Query the database for a user with the specified email
                var user = await _userManager.Users
                    .FirstOrDefaultAsync(u => u.Email == email);

                return user;
            }
            catch (Exception ex)
            {
                // Log exception if necessary
                throw new Exception($"Error retrieving user by email: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Finds a user by email or username.
        /// </summary>
        public async Task<UsersModel?> FindUserByEmailOrUsernameAsync(string identifier)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(identifier) ??
                           await _userManager.FindByNameAsync(identifier);

                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error finding user by identifier: {Identifier}", identifier);
                return null;
            }
        }

        /// <summary>
        /// Updates the last login date for the user.
        /// </summary>
        public async Task<bool> UpdateLastLoginAsync(string userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    _logger.LogWarning("User not found: {UserId}", userId);
                    return false;
                }

                user.U_Last_Login = DateTime.UtcNow;
                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User last login updated: {UserId}", userId);
                    return true;
                }
                else
                {
                    _logger.LogWarning("Failed to update last login for user: {UserId}", userId);
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating last login for user: {UserId}", userId);
                return false;
            }
        }

        /// <summary>
        /// Updates custom user details.
        /// </summary>
        public async Task<bool> UpdateUserDetailsAsync(UsersModel updatedUser)
        {
            try
            {
                var existingUser = await _userManager.FindByIdAsync(updatedUser.Id);
                if (existingUser == null)
                {
                    _logger.LogWarning("User not found: {UserId}", updatedUser.Id);
                    return false;
                }

                existingUser.U_Age = updatedUser.U_Age;
                existingUser.U_Height_CM = updatedUser.U_Height_CM;
                existingUser.U_Weight_KG = updatedUser.U_Weight_KG;
                existingUser.U_Goal = updatedUser.U_Goal;
                existingUser.U_Lifestyle_Condition_1 = updatedUser.U_Lifestyle_Condition_1;
                existingUser.U_Lifestyle_Condition_2 = updatedUser.U_Lifestyle_Condition_2;
                existingUser.U_Lifestyle_Condition_3 = updatedUser.U_Lifestyle_Condition_3;
                existingUser.U_Lifestyle_Condition_4 = updatedUser.U_Lifestyle_Condition_4;
                existingUser.U_Lifestyle_Condition_5 = updatedUser.U_Lifestyle_Condition_5;

                var result = await _userManager.UpdateAsync(existingUser);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User details updated successfully: {UserId}", updatedUser.Id);
                    return true;
                }
                else
                {
                    _logger.LogWarning("Failed to update user details: {Errors}", string.Join(", ", result.Errors.Select(e => e.Description)));
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating user details: {UserId}", updatedUser.Id);
                return false;
            }
        }
    }
}
