﻿using ExerciseXData.Models;
using Microsoft.EntityFrameworkCore;
using ExerciseXData.Interfaces;
using ExerciseXData.Data;
using ExerciseXDataLibrary.Repositories;
using ExerciseXDataLibrary.Models;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseXData.Services
{
    public class UsersService
    {
        private readonly UsersRepository _usersRepository;
        private readonly DietsRepository _dietsRepository;
        private readonly ExercisesRepository _exercisesRepository;
        private readonly AppDbContext _context;

        public UsersService(AppDbContext context, UsersRepository usersRepo, DietsRepository dietsRepo, ExercisesRepository exercisesRepo)
        {
            _context = context;
            _usersRepository = usersRepo;
            _dietsRepository = dietsRepo;
            _exercisesRepository = exercisesRepo;
        }

        
        public async Task<bool> RegisterUserAsync(string email, string userName, string password, string gender, 
            int age, double height, double weight, string goal)
        {
            // Example: additional validation, or orchestration between repositories
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Email and Password are required");
            }

            // Register user through repository (with additional business logic as needed)
            return await _usersRepository.RegisterUserAsync(email, userName, password, gender, age, height, weight, goal);
        }

        //public async Task<bool> AddUserAndAssignPlanAsync(int userId, int exerciseId, int dietId)
        //{
        //    using (var transaction = await _context.Database.BeginTransactionAsync())
        //    {
        //        try
        //        {
        //            // Call repository to add user's exercise
        //            await _exercisesRepository.AddUserExerciseAsync(userId, exerciseId);

        //            // Call repository to add user's diet
        //            await _dietsRepository.AddUserDietAsync(userId, dietId);

        //            // Commit if all operations succeed
        //            await _context.SaveChangesAsync();
        //            await transaction.CommitAsync();
        //            return true;
        //        }
        //        catch (Exception)
        //        {
        //            // Rollback transaction on failure
        //            await transaction.RollbackAsync();
        //            return false; // Handle exception appropriately
        //        }
        //    }
        //}
    }
}
    

        //public async Task UpdateUserDietAsync(int userId, int dietId, string goals)
        //{
        //    await _usersRepository.UpdateUserDietAsync(userId, dietId, goals);
        //}
    

