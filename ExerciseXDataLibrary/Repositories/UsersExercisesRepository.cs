using ExerciseXData.Data;
using ExerciseXData.Models;
using ExerciseXDataLibrary.Data;
using ExerciseXDataLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseXDataLibrary.Repositories
{
    public class UsersExercisesRepository 
    { 
        private readonly UserDbContext _userContext;
        public UsersExercisesRepository(UserDbContext userContext)
        {
            _userContext = userContext;
        }
        public Task<List<UsersExercisesModel>> GetByUserId(int userId) =>
            _userContext.UsersExercises.Where(ue => ue.U_Id == userId).ToListAsync();
    }
}
