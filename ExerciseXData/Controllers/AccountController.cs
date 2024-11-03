using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ExerciseXData.Services;
using ExerciseXDataLibrary.DataTransferObject;

namespace ExerciseXData.Controllers
{
    public class AccountController : Controller
    {
        private readonly UsersService _userService;

        public AccountController(UsersService userService) // Injected UsersService
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }



        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto dto)
        {
            var result = await _userService.RegisterUserAsync(dto.Email, dto.UserName, dto.Password, dto.Gender, dto.Age,
                dto.Height, dto.Weight, dto.Goal);
            if (result)
                return Ok("User registered successfully.");
            return BadRequest("Registration failed.");
        }
    }

}
