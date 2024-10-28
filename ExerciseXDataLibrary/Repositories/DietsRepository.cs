using ExerciseXData.Data;
using ExerciseXData.Interfaces;
using ExerciseXData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseXDataLibrary.Repositories
{
    public class DietsRepository
    {
        private readonly AppDbContext _context;

        public DietsRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddUserDietAsync(int userId, int dietId)
        {
            var usersDiets = new UsersDietsModel
            {
                U_Id = userId,
                D_Id = dietId,
            };

            _context.UsersDiets.Add(usersDiets);
            await _context.SaveChangesAsync();
        }

    }
}
