using ExerciseXData.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseXData.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("admin/dashboard")]
        public async Task<IActionResult> AdminDashboard()
        {
            var dashboardData = await _adminService.GetAdminDashboardDataAsync();
            if (dashboardData == null)
            {
                return NotFound("Dashboard data not found.");
            }
            return View(dashboardData);
        }
    }
}
