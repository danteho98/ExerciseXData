using ExerciseXData_DietLibrary.Data;

namespace ExerciseXData_DietLibrary.Repositories
{
    public class UsersDietsRepository/* : IUsersDietsRepository*/
    {
        private readonly DietDbContext _dietDbContext;

        public UsersDietsRepository(DietDbContext dietDbContext)
        {
            _dietDbContext = dietDbContext;
        }

       
    }
}
