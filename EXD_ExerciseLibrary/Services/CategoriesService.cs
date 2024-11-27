
using ExerciseXData_ExerciseLibrary.Data;


namespace ExerciseXData_ExerciseLibrary.Services
{

    public class CategoriesService
    {

        private readonly ExerciseDbContext _categoryContext;

        public CategoriesService(ExerciseDbContext categoryContext)
        {
            _categoryContext = categoryContext;
        }



    }
}