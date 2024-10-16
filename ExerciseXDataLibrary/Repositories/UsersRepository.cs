using ExerciseXData.Data;
using ExerciseXData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        
        public async Task<bool> AddUserWithExercisesAndDietAsync(int userId, int exerciseId, int dietId)
        {

        using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    // Add a new exercise for a user
                    var userExercise = new UsersExercises
                    {
                        U_Id = userId,
                        E_Id = exerciseId
                    };
                    
                    _context.UsersExercises.Add(userExercise);

                    // Add a new diet for a user
                    var userDiet = new UsersDiets
                    {
                        U_Id = userId,
                        D_Id = dietId
                    };
                    
                    _context.UsersDiets.Add(userDiet);
                    
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

        public async Task UpdateUserDietAsync(int userId, int dietId, string foodName, int foodQuantity, int foodCalories, int totalCalories)
        {
            var userDiet = await _context.UsersDiets.FirstOrDefaultAsync(ud => ud.U_Id == userId && ud.D_Id == dietId);

            if (userDiet != null)
            {
                // Update specific fields of the user's diet
                userDiet.Food_Name = foodName;
                userDiet.Food_Quantity = foodQuantity;
                userDiet.Food_Calories = foodCalories;
                userDiet.Total_Calaroies = totalCalories;


                // Save the changes
                await _context.SaveChangesAsync();
            }
            else
            {
                // Handle case where the user-diet relationship doesn't exist
                throw new Exception("UserDiet record not found");
            }
        }
    }
}
