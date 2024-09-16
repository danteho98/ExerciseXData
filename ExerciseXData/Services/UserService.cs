using ExerciseXData.Models;
using Microsoft.EntityFrameworkCore;
using ExerciseXData.Interfaces;
using ExerciseXData.Data;

namespace ExerciseXData.Services
{
    public class UserService : IUserService 
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext usercontext)
        {
            _context = usercontext;
        }

        public async Task AddAsync(Users user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Users.FirstOrDefaultAsync(n => n.U_Id == id);
            _context.Users.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Users>> GetAllAsync()
        {
            var result = await _context.Users.ToListAsync();
            return result;
        }

        public async Task<Users> GetByIdAsync(int id)
        {
            var result = await _context.Users.FirstOrDefaultAsync(n => n.U_Id == id);
            return result;
        }

        public async Task<Users> UpdateAsync(int id, Users newUser)
        {
            _context.Update(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }
    }
}