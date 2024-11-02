using ExerciseXData.Models;
using Microsoft.EntityFrameworkCore;
using ExerciseXData.Interfaces;
using ExerciseXData.Data;
using ExerciseXDataLibrary.Repositories;
using ExerciseXDataLibrary.Models;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using ExerciseXDataLibrary.Data;

namespace ExerciseXData.Services
{
    public class UsersService
    {
        private readonly UserDbContext _userDbContext;
        private readonly UsersRepository _usersRepository;

        private readonly AppDbContext _context;

        public UsersService(AppDbContext context, UserDbContext userDbContext)
        {
            _context = context;
            _userDbContext = userDbContext;

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
    }
}