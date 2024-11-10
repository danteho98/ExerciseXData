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

namespace ExerciseXDataLibrary.Repositories
{
    public class UsersRepository
    {
        private readonly UserDbContext _userDbContext;
        private readonly ILogger<UsersRepository> _logger;

        public UsersRepository(UserDbContext userDbContext, ILogger<UsersRepository> logger)
        {
            _userDbContext = userDbContext;
            _logger = logger;
        }

        public async Task<bool> RegisterUserAsync(string email, string userName, string password, Gender gender, int age, double height, 
            double weight, string goal, string lifeStyle1, string lifeStyle2, string lifeStyle3, string lifeStyle4, string lifeStyle5)
        {
            using var transaction = await _userDbContext.Database.BeginTransactionAsync();
            try
            {
                // Step 1: Create a new user entry
                var newUser = new UsersModel
                {
                    U_Email = email,
                    U_Name = userName,
                    Gender = gender,
                    Age = age,
                    Role = "NormalUser", //Default role
                    Height_CM = height,
                    Weight_KG = weight,
                    Goal = goal,
                    Lifestyle_Condition_1 = lifeStyle1,
                    Lifestyle_Condition_2 = lifeStyle2,
                    Lifestyle_Condition_3 = lifeStyle3,
                    Lifestyle_Condition_4 = lifeStyle4,
                    Lifestyle_Condition_5 = lifeStyle5,
                    U_Created_Date = DateTime.UtcNow,
                    U_Last_Login = DateTime.UtcNow
                };

                // Role validation to ensure the role is always "NormalUser" at registration
                if (newUser.Role != "NormalUser")
                {
                    throw new UnauthorizedAccessException("Role assignment is restricted.");
                }

                await _userDbContext.Users.AddAsync(newUser);
                await _userDbContext.SaveChangesAsync();

                _logger.LogInformation("User added to Users table with ID: {UserId}", newUser.U_Id);


                // Step 2: Generate Salt and Hash for Password
                var salt = GenerateSalt();
                var hash = GenerateHash(password, salt);

                // Step 3: Create user credentials entry
                var userCredentials = new UsersCredentialsModel
                {
                    U_Id = newUser.U_Id,
                    //Password = null,  // Do not store plain password
                    Password_Hush = hash,
                    Password_Salt = salt,
                    Last_Updated = DateTime.UtcNow
                };

                await _userDbContext.UsersCredentials.AddAsync(userCredentials);
                await _userDbContext.SaveChangesAsync();

                _logger.LogInformation("User credentials added for UserId: {UserId}", newUser.U_Id);


                // Commit the transaction if everything is successful
                await transaction.CommitAsync();
                _logger.LogInformation("User registration transaction committed successfully for UserId: {UserId}", newUser.U_Id);

                return true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during user registration for email: {Email}", email);
                // Roll back the transaction in case of failure
                await transaction.RollbackAsync();
                return false; // Handle the error as needed
            }
        }
        private string GenerateSalt()
        {
            byte[] saltBytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        private string GenerateHash(string password, string salt)
        {
            using var sha256 = SHA256.Create();
            var saltedPassword = $"{salt}{password}";
            var saltedPasswordBytes = Encoding.UTF8.GetBytes(saltedPassword);
            var hashBytes = sha256.ComputeHash(saltedPasswordBytes);
            return Convert.ToBase64String(hashBytes);
        }

        public async Task<bool> LoginUserAsync(string username, string password)
        {
            var user = await _userDbContext.Users.SingleOrDefaultAsync(u => u.U_Name == username);

            if (user == null)
            {
                _logger.LogWarning("Login failed: User not found with username {Username}", username);
                return false;
            }

            var userCredentials = await _userDbContext.UsersCredentials.SingleOrDefaultAsync(uc => uc.U_Id == user.U_Id);

            if (userCredentials == null)
            {
                _logger.LogWarning("Login failed: Credentials not found for User ID {UserId}", user.U_Id);
                return false;
            }

            // Generate hash of the provided password using the stored salt
            string inputHash = GenerateHash(password, userCredentials.Password_Salt);

            // Verify password by comparing the hash
            if (inputHash == userCredentials.Password_Hush)
            {
                // Successful login
                _logger.LogInformation("Login successful for User ID {UserId}", user.U_Id);
                user.U_Last_Login = DateTime.UtcNow;
                await _userDbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                // Invalid password
                _logger.LogWarning("Login failed: Incorrect password for User ID {UserId}", user.U_Id);
                return false;
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

}
