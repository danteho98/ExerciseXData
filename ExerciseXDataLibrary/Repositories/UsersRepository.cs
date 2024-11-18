using ExerciseXData.Data;
using ExerciseXData.Models;
using ExerciseXDataLibrary.Data;
using ExerciseXDataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using static ExerciseXDataLibrary.Models.UsersModel;
using static ExerciseXDataLibrary.Models.UserGender;
using Microsoft.AspNetCore.Identity;


namespace ExerciseXDataLibrary.Repositories
{
    public class UsersRepository
    {
        private readonly UserDbContext _userDbContext; 
        private readonly UserManager<IdentityUser> _userManager; // Using UserManager with IdentityUser
        private readonly RoleManager<IdentityRole> _roleManager; // For role management

        private readonly ILogger<UsersRepository> _logger;

        public UsersRepository(
            UserDbContext userDbContext,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<UsersRepository> logger)
        {
            _userDbContext = userDbContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }

        public async Task<bool> RegisterUserAsync(
            string email, string userName, string password, Gender gender, int age, double height,
            double weight, string goal, string lifeStyle1, string lifeStyle2, string lifeStyle3, string lifeStyle4, string lifeStyle5)
        {
            using var transaction = await _userDbContext.Database.BeginTransactionAsync();
            try
            {
                // Step 1: Check if the email is already registered
                if (await _userManager.FindByEmailAsync(email) != null)
                {
                    _logger.LogWarning("Registration failed: Email already in use - {Email}", email);
                    return false;
                }

                // Step 2: Create IdentityUser
                var identityUser = new IdentityUser
                {
                    UserName = userName,
                    Email = email
                };

                var createResult = await _userManager.CreateAsync(identityUser, password);
                if (!createResult.Succeeded)
                {
                    foreach (var error in createResult.Errors)
                    {
                        _logger.LogError("UserManager error: {Error}", error.Description);
                    }
                    return false;
                }

                // Step 3: Assign "NormalUser" role
                if (!await _roleManager.RoleExistsAsync("NormalUser"))
                {
                    await _roleManager.CreateAsync(new IdentityRole("NormalUser"));
                }
                await _userManager.AddToRoleAsync(identityUser, "NormalUser");

                // Step 4: Create custom user details entry
                var newUser = new UsersModel
                {
                    U_Email = email,
                    U_Username = userName,
                    U_Gender = gender,
                    U_Role = "NormalUser",
                    U_Age = age,
                    U_Height_CM = height,
                    U_Weight_KG = weight,
                    U_Goal = goal,
                    U_Lifestyle_Condition_1 = lifeStyle1,
                    U_Lifestyle_Condition_2 = lifeStyle2,
                    U_Lifestyle_Condition_3 = lifeStyle3,
                    U_Lifestyle_Condition_4 = lifeStyle4,
                    U_Lifestyle_Condition_5 = lifeStyle5,
                    U_Created_Date = DateTime.UtcNow,
                    U_Last_Login = DateTime.UtcNow
                };

                await _userDbContext.Users.AddAsync(newUser);
                await _userDbContext.SaveChangesAsync();

                // Commit the transaction
                await transaction.CommitAsync();
                _logger.LogInformation("User registered successfully with ID: {UserId}", newUser.U_Id);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during user registration for email: {Email}", email);
                await transaction.RollbackAsync();
                return false;
            }




        }
     

        public async Task<bool> LoginUserAsync(string email, string password)
        {
            try
            {
                var identityUser = await _userManager.FindByEmailAsync(email);
                if (identityUser == null)
                {
                    _logger.LogWarning("Login failed: User not found with email {Email}", email);
                    return false;
                }

                var isPasswordValid = await _userManager.CheckPasswordAsync(identityUser, password);
                if (!isPasswordValid)
                {
                    _logger.LogWarning("Login failed: Incorrect password for user {UserName}", identityUser.UserName);
                    return false;
                }

                var user = await _userDbContext.Users.SingleOrDefaultAsync(u => u.U_Email == email);
                if (user != null)
                {
                    user.U_Last_Login = DateTime.UtcNow;
                    await _userDbContext.SaveChangesAsync();
                }

                _logger.LogInformation("Login successful for user {UserName}", identityUser.UserName);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during login for email: {Email}", email);
                return false;
            }
        }

        public async Task<UsersModel?> GetUserByEmailAsync(string email)
        {
            try
            {
                var user = await _userDbContext.Users
                    .Include(u => u.UsersExercises)
                    .Include(u => u.UsersDiets)
                    .FirstOrDefaultAsync(u => u.U_Email == email);

                if (user == null)
                {
                    _logger.LogWarning("User not found with email: {Email}", email);
                    return null;
                }

                _logger.LogInformation("User retrieved with ID: {UserId}", user.U_Id);
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
                var user = await _userDbContext.Users
                    .Include(u => u.UsersExercises)
                    .Include(u => u.UsersDiets)
                    .FirstOrDefaultAsync(u => u.U_Email == email);

                var identityUser = await _userManager.FindByEmailAsync(email);

                return (user, identityUser);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving user and identity by email: {Email}", email);
                return (null, null);
            }
        }
    }
}
    //public async Task<bool> AddUserWithExercisesAndDietAsync(int userId, int exerciseId, int dietId)
    //{

    //    using (var transaction = await _userDbContext.Database.BeginTransactionAsync())
    //    {
    //        try
    //        {
    //            // Add a new exercise for a user
    //            var userExercise = new UsersExercisesModel
    //            {
    //                U_Id = userId,
    //                E_Id = exerciseId
    //            };

    //            _userDbContext.UsersExercises.Add(userExercise);

    //            // Add a new diet for a user
    //            var userDiet = new UsersDietsModel
    //            {
    //                U_Id = userId,
    //                D_Id = dietId
    //            };

    //            _userDbContext.UsersDiets.Add(userDiet);

    //            await _userDbContext.SaveChangesAsync();

    //            // Commit the transaction if everything is successful
    //            await transaction.CommitAsync();
    //            return true;

    //        }

    //        catch (Exception)
    //        {
    //            // Roll back the transaction in case of failure
    //            await transaction.RollbackAsync();
    //            return false; // Handle the error as needed
    //        }
    //    }
    //}


