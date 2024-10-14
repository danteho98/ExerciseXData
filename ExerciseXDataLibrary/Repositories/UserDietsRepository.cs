using ExerciseXData.Data;
using ExerciseXData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseXDataLibrary.Repositories
{
    public class UserDietsRepository
    {
        private readonly AppDbContext _context;
        public UsersDietsRepository(AppDbContext context) { _context = context; }

        public Task<List<UsersDiets>> GetByDietId(int userId) =>
            _context.DietsFoods.Where(ud => ud.U_Id == userId).ToListAsync();
    }
}
