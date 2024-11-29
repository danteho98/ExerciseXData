
using ExerciseXData_ExerciseLibrary.Interface;
using ExerciseXData_SharedContracts.Interfaces;


namespace ExerciseXData.Admin
{
    public class AdminService : IAdminService
    {
        
        private readonly IUserRepository _userRepository;
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IDietRepository _dietRepository;

        public AdminService(
            IUserRepository userRepository, IExerciseRepository exerciseRepository, IDietRepository dietRepository)
        {
            
            _userRepository = userRepository;
            _exerciseRepository = exerciseRepository;
            _dietRepository = dietRepository;
        }

        public async Task<AdminDashboardDto> GetAdminDashboardDataAsync()
        {
            var totalUsers = await _userRepository.GetTotalUsersAsync();
            var totalExercises = await _exerciseRepository.GetTotalExercisesAsync();
            var totalDiets = await _dietRepository.GetTotalDietsAsync();

            return new AdminDashboardDto
            {
                TotalUsers = totalUsers,
                TotalExercises = totalExercises,
                TotalDiets = totalDiets
            };
        }

        //public async Task<bool> AddExerciseCategoryAsync(CategoriesModel category)
        //{
        //    try
        //    {
        //        category.C_Modified_Date = DateTime.UtcNow;
        //        await _exerciseDbContext.Categories.AddAsync(category); // Assuming your DbSet is named `Categories`
        //        await _context.SaveChangesAsync();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

    }
}
