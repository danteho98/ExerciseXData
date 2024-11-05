using ExerciseXData.Data;
using ExerciseXData.Models;
using ExerciseXDataLibrary.Data;
using ExerciseXDataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseXDataLibrary.Repositories
{
    public class DietsRepository
    {
        private readonly UserDbContext _userContext;

        public DietsRepository(UserDbContext userContext)
        {
            _userContext = userContext;
        }
        public async Task AddUserDietAsync(int userId, int dietId)
        {
            var usersDiets = new UsersDietsModel
            {
                U_Id = userId,
                D_Id = dietId,
            };

            _userContext.UsersDiets.Add(usersDiets);
            await _userContext.SaveChangesAsync();
        }

    }
}
