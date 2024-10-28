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
    public class UsersDietsRepository
    {
        private readonly AppDbContext _context;
        public UsersDietsRepository(AppDbContext context)
        {
            _context = context; 
        }

        public Task<List<UsersDietsModel>> GetByDietId(int userId) =>
            _context.UsersDiets.Where(ud => ud.U_Id == userId).ToListAsync();
    }
}
