namespace ExerciseXData.Admin
{
    public interface IAdminService
    {
        Task<AdminDashboardDto> GetAdminDashboardDataAsync();
    }

}
