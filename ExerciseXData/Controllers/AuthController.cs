using ExerciseXData.Data;
using ExerciseXDataLibrary.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseXData.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class AuthController : ControllerBase
    {
        //private readonly AuthService _authService;
        //private readonly AppDbContext _context;

        //public AuthController(AuthService authService, AppDbContext context)
        //{
        //    _authService = authService;
        //    _context = context;
        //}

        //[HttpPost("login")]
        //public IActionResult Login([FromBody] LoginModel model)
        //{
        //    // Authenticate the user
        //    var token = _authService.Authenticate(model.Username, model.Password);
        //    if (token == null)
        //    {
        //        return Unauthorized("Invalid credentials");
        //    }

        //    // Get user details to check role
        //    var user = _context.Users.SingleOrDefault(u => u.U_Email == model.Username);

        //    // Redirect based on role
        //    if (user.Role == "Admin")
        //    {
        //        return RedirectToAction("AdminDashboard", "Admin");
        //    }
        //    else if (user.Role == "User")
        //    {
        //        return RedirectToAction("UserDashboard", "User");
        //    }

        //    return Unauthorized("Unknown role");
        //}
    }
}
