using System;
using System.Linq;
using System.Threading.Tasks;
using ExerciseXData_SharedContracts.Interfaces;
using ExerciseXData_UserLibrary.Data;
using ExerciseXData_UserLibrary.DataTransferObject;
using ExerciseXData_UserLibrary.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ExerciseXData_UserLibrary.Repositories
{
    public class UsersRepository : IUserRepository
    {
        private readonly UserDbContext _userDbContext;
        private readonly UserManager<UsersModel> _userManager;
        private readonly SignInManager<UsersModel> _signInManager;
        private readonly ILogger<UsersRepository> _logger;

        public UsersRepository(
            UserDbContext userDbContext,
            UserManager<UsersModel> userManager,
            SignInManager<UsersModel> signInManager,
            ILogger<UsersRepository> logger)
        {
            _userDbContext = userDbContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        // Create a user in the database
        public async Task<bool> CreateAsync(UsersModel user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                _logger.LogInformation("User created successfully: {Email}", user.Email);
                return true;
            }

            _logger.LogWarning("User creation failed: {Errors}", string.Join(", ", result.Errors.Select(e => e.Description)));
            return false;
        }

        // Authenticate user credentials
        public async Task<bool> AuthenticateAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                _logger.LogWarning("Authentication failed: User not found for email: {Email}", email);
                return false;
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, password, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                _logger.LogInformation("Authentication succeeded for user: {Email}", email);
                return true;
            }

            _logger.LogWarning("Authentication failed for user: {Email}", email);
            return false;
        }

        // Get user by ID
        public async Task<UsersModel?> GetUserByIdAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        // Update user details
        public async Task<bool> UpdateUserDetailsAsync(UsersModel updatedUser)
        {
            var result = await _userManager.UpdateAsync(updatedUser);
            if (result.Succeeded)
            {
                _logger.LogInformation("User updated successfully: {UserId}", updatedUser.Id);
                return true;
            }

            _logger.LogWarning("Failed to update user: {Errors}", string.Join(", ", result.Errors.Select(e => e.Description)));
            return false;
        }

        // Sign out the user
        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User signed out successfully.");
        }

        /// <summary>
        /// Checks if a user with the given email or username exists.
        /// </summary>
        /// <param name="identifier">Email or Username to check.</param>
        /// <returns>True if user exists; otherwise, false.</returns>
        public async Task<bool> UserExistsAsync(string identifier)
        {
            // Check for user by email
            var userByEmail = await _userManager.FindByEmailAsync(identifier);
            if (userByEmail != null)
            {
                return true;
            }

            // Check for user by username
            var userByUsername = await _userManager.FindByNameAsync(identifier);
            if (userByUsername != null)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Resets a user's password using a reset token.
        /// </summary>
        /// <param name="email">The user's email.</param>
        /// <param name="newPassword">The new password to set.</param>
        /// <param name="token">The password reset token.</param>
        /// <returns>True if the password reset is successful; otherwise, false.</returns>
        public async Task<bool> ResetPasswordAsync(string email, string newPassword, string token)
        {
            // Find the user by email
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return false; // User not found
            }

            // Reset the password
            var result = await _userManager.ResetPasswordAsync(user, token, newPassword);

            return result.Succeeded;
        }

        /// <summary>
        /// Change the user's password after validating the current one.
        /// </summary>
        public async Task<bool> ChangePasswordAsync(string userId, string currentPassword, string newPassword)
        {
            try
            {
                // Find the user by ID
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return false; // User not found
                }

                // Check if the current password is valid
                var isPasswordValid = await _userManager.CheckPasswordAsync(user, currentPassword);
                if (!isPasswordValid)
                {
                    return false; // Current password is incorrect
                }

                // Change the password
                var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
                return result.Succeeded;
            }
            catch (Exception ex)
            {
                // Log any errors (you can also log more details if needed)
                throw new Exception("Error occurred while changing the password.", ex);
            }
        }


        //public async Task<List<SecurityQuestionModel>> GetSecurityQuestionsForUserAsync(string userId)
        //{
        //    // Ensure the method queries the UserSecurityQuestions table to find the user's associated security questions
        //    var userQuestions = await _userDbContext.UserSecurityQuestions
        //        .Where(usc => usc.U_Id == userId)
        //        .Include(usc => usc.UserSecurityQuestions) // Include the related SecurityQuestion entity
        //        .Select(usc => usc.UserSecurityQuestions)  // Select only the SecurityQuestion part
        //        .ToListAsync();

        //    return userQuestions;
        //}


        public async Task<int> GetTotalUsersAsync()
        {
            return await _userDbContext.Users.CountAsync();
        }

        public async Task<UsersModel> FindByEmailOrUsernameAsync(string emailOrUsername)
        {
            return await _userDbContext.Users
            //    .Include(u => u.UserExercises)
            //        .ThenInclude(ue => ue.ExercisePlan) // Assuming UserExercises has ExercisePlan navigation property
            //    .Include(u => u.UserDiets)
            //        .ThenInclude(ud => ud.DietPlan) // Assuming UserDiets has DietPlan navigation property
                .FirstOrDefaultAsync(u => u.Email == emailOrUsername || u.UserName == emailOrUsername);
        }
    }


}