using ExerciseXData.Data;
using ExerciseXData.Models;
using ExerciseXDataLibrary.Data;
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
        private readonly UserDbContext _userContext;
        public UsersDietsRepository(UserDbContext userContext)
        {
            _userContext = userContext; 
        }

        public Task<List<UsersDietsModel>> GetByDietId(int userId) =>
            _userContext.UsersDiets.Where(ud => ud.U_Id == userId).ToListAsync();
    }
}
