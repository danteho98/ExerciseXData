using ExerciseXData.Admin;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseXData.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly ILogger<AdminController> _logger;

        public AdminController(IAdminService adminService, ILogger<AdminController> logger)
        {
            _adminService = adminService;
            _logger = logger;
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

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            _logger.LogInformation("Admin logged out successfully.");
            return RedirectToAction("Login", "Account"); // Redirect to the admin login page or other appropriate page
        }


    }
}
