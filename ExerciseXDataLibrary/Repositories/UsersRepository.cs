using ExerciseXData.Data;
using ExerciseXData.Models;
using ExerciseXDataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseXDataLibrary.Repositories
{
    public class UsersRepository
    {
        private readonly AppDbContext _context;
        public UsersRepository(AppDbContext context)
        {
            _context = context;
        }

        
        public async Task<bool> RegisterUserAsync(string email, string userName, string password, string gender, int age, 
            double height, double weight, string goal)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    // Step 1: Create a new user entry
                    var newUser = new UsersModel
                    {
                        U_Email = email,
                        U_Name = userName,
                        Gender = gender,
                        Age = age,
                        Role = "Normal User", //Default role
                        Height = height,
                        Weight = weight,
                        Goal = goal,
                        U_Created_Date = DateTime.UtcNow,
                        U_Last_Login = DateTime.UtcNow
                    };

                    // Role validation to ensure the role is always "NormalUser" at registration
                    if (newUser.Role != "NormalUser")
                    {
                        throw new UnauthorizedAccessException("Role assignment is restricted.");
                    }

                    await _context.Users.AddAsync(newUser);
                    await _context.SaveChangesAsync();

                    // Step 2: Generate Salt and Hash for Password
                    var salt = GenerateSalt();
                    var hash = GenerateHash(password, salt);

                    // Step 3: Create user credentials entry
                    var userCredentials = new UsersCredentialsModel
                    {
                        U_Id = newUser.U_Id,
                        Password = null,  // Do not store plain password
                        Password_Hush = hash,
                        Password_Salt = salt,
                        Last_Updated = DateTime.UtcNow
                    };

                    await _context.UsersCredentials.AddAsync(userCredentials);
                    await _context.SaveChangesAsync();

                    // Commit the transaction if everything is successful
                    await transaction.CommitAsync();
                    return true;
                }
                catch (Exception)
                {
                    // Roll back the transaction in case of failure
                    await transaction.RollbackAsync();
                    return false; // Handle the error as needed
                }
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
            using (var sha256 = SHA256.Create())
            {
                var saltedPassword = $"{salt}{password}";
                var saltedPasswordBytes = Encoding.UTF8.GetBytes(saltedPassword);
                var hashBytes = sha256.ComputeHash(saltedPasswordBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }
        //public async Task<bool> AddUserWithExercisesAndDietAsync(int userId, int exerciseId, int dietId)
        //{

        //using (var transaction = await _context.Database.BeginTransactionAsync())
        //    {
        //        try
        //        {
        //            // Add a new exercise for a user
        //            var userExercise = new UsersExercisesModel
        //            {
        //                U_Id = userId,
        //                E_Id = exerciseId
        //            };
                    
        //            _context.UsersExercises.Add(userExercise);

        //            // Add a new diet for a user
        //            var userDiet = new UsersDietsModel
        //            {
        //                U_Id = userId,
        //                D_Id = dietId
        //            };
                    
        //            _context.UsersDiets.Add(userDiet);
                    
        //            await _context.SaveChangesAsync();
                    
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
}

// Method to update a user's specific diet information
//public async Task UpdateUserDietAsync(int userId, int dietId, string foodName, int foodQuantity, int foodCalories, int totalCalories)
//{
//    var userDiet = await _context.UsersDiets.FirstOrDefaultAsync(ud => ud.U_Id == userId && ud.D_Id == dietId);

//    // If the record exists, update it
//    if (userDiet != null)
//    {
//        // Update specific fields of the user's diet
//        userDiet.Food_Name = foodName;
//        userDiet.Food_Quantity = foodQuantity;
//        userDiet.Food_Calories = foodCalories;
//        userDiet.Total_Calaroies = totalCalories;


//        // Save the changes
//        await _context.SaveChangesAsync();
//    }
//    else
//    {
//        // Handle case where the user-diet relationship doesn't exist
//        throw new Exception("UserDiet record not found");
//    }
//}

