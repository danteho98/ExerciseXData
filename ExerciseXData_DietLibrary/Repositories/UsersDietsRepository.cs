using ExerciseXData_DietLibrary.Data;
using ExerciseXData_DietLibrary.Models;
using ExerciseXData_SharedContracts.DataTransferObjects;
using ExerciseXData_SharedContracts.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseXData_DietLibrary.Repositories
{
    public class UsersDietsRepository : IUsersDietsRepository
    {
        private readonly DietDbContext _context;

        public UsersDietsRepository(DietDbContext context)
        {
            _context = context;
        }

        public async Task<List<IUsersDiets>> GetUsersDietByUserIdAsync(int userId)
        {
            return await _context.UsersDiets
                .Where(ud => ud.UserId == userId)
                .Select(ud => new IUsersDiets
                {
                    UserId = ud.UserId,
                    DietId = ud.DietId,
                    DietName = ud.DietName, // Adjust fields as needed
                    DietDetails = ud.DietDetails
                })
                .ToListAsync();
        }

        public async Task AddUserDietAsync(IUsersDiets model)
        {
            var newModel = new UsersDietsModel
            {
                UserId = model.UserId,
                DietId = model.DietId,
                DietName = model.DietName,
                DietDetails = model.DietDetails
            };

            await _context.UsersDiets.AddAsync(newModel);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveUserDietAsync(int userId, int dietId)
        {
            var entry = await _context.UsersDiets.FirstOrDefaultAsync(
                ud => ud.UserId == userId && ud.DietId == dietId);

            if (entry != null)
            {
                _context.UsersDiets.Remove(entry);
                await _context.SaveChangesAsync();
            }
        }
    }
}
