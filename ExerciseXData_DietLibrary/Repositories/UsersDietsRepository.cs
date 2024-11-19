
using ExerciseXData_DietLibrary.Data;


namespace ExerciseXData_DietLibrary.Repositories
{
    public class UsersDietsRepository
    {
        private readonly DietDbContext _dietContext;
        public UsersDietsRepository(DietDbContext dietContext)
        {
            _dietContext = dietContext; 
        }

    //    public Task<List<UsersDietsModel>> GetByDietId(int userId) =>
    //        _userContext.UsersDiets.Where(ud => ud.U_Id == userId).ToListAsync();
    }
}
