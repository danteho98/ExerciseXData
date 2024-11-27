using ExerciseXData_SharedContracts.Interfaces;
using ExerciseXData_UserLibrary.Repositories;

namespace ExerciseXData.Admin
{
    public class AdminService : IAdminService
    {
        private readonly IUserRepository _userRepository;
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IDietRepository _dietRepository;

        public AdminService(IUserRepository userRepository, IExerciseRepository exerciseRepository, IDietRepository dietRepository)
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
    }
}
