using Microsoft.AspNetCore.Mvc;
using ExerciseXData.Models;
using ExerciseXData.Services;

using ExerciseXDataLibrary.DataTransferObject;

namespace ExerciseXDataApi.Controllers
{
    [Route("api/userAPI")] //The route here maintains across all users when accessed even if controller name changes in the future
    [ApiController]
    public class UsersApiController : Controller
    {
        private readonly UsersService _userService;

        public UsersApiController(UsersService userService) // Injected UserService
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return validation errors
            }

            try
            {
                var result = await _userService.RegisterUserAsync(dto.Email, dto.UserName, dto.Password, dto.Gender, dto.Age,
                    dto.Height, dto.Weight, dto.Goal);
                return Ok("User registered successfully.");

                return BadRequest("Registration failed.");
            }
            catch (Exception ex)
            {
                // Log the exception (not shown here)
                return StatusCode(500, "Internal server error"); // Handle server errors
            }
        }
    }
}

