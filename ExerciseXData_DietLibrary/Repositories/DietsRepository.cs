

using ExerciseXData_DietLibrary.Data;

namespace ExerciseXData_DietLibrary.Repositories
{
    public class DietsRepository
    {
        private readonly DietDbContext _dietContext;

        public DietsRepository(DietDbContext dietContext)
        {
            _dietContext = dietContext;
        }
        //public async Task AddUserDietAsync(int userId, int dietId)
        //{
        //    var usersDiets = new UsersDietsModel
        //    {
        //        U_Id = userId,
        //        D_Id = dietId,
        //    };

        //    _userContext.UsersDiets.Add(usersDiets);
        //    await _userContext.SaveChangesAsync();
        //}

    }
}
