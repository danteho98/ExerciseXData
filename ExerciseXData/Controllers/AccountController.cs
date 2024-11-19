using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ExerciseXDataLibrary.DataTransferObject;
using ExerciseXDataLibrary.Services;
using System.ComponentModel;
//using static ExerciseXDataLibrary.Models.UsersModel;
//using static ExerciseXDataLibrary.Models.UserGender;
using ExerciseXDataLibrary.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace ExerciseXData.Controllers
{
    public class AccountController : Controller
    {
        private readonly UsersService _usersService;
        private readonly UsersRepository _usersRepository;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<AccountController> _logger;


        public AccountController(UsersService usersService, ILogger<AccountController> logger)
        {
            _usersService = usersService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken] // Prevents CSRF attacks
        //public async Task<IActionResult> Register(RegisterUserDto registerDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        _logger.LogWarning("Invalid registration data received.");
        //        return BadRequest(ModelState);
        //    }

        //    var result = await _usersService.RegisterUserAsync(
        //        registerDto.Email,
        //        registerDto.UserName,
        //        registerDto.Password,
        //        registerDto.Gender,
        //        registerDto.Age,
        //        registerDto.Height,
        //        registerDto.Weight,
        //        registerDto.Goal,
        //        registerDto.Lifestyle_Condition_1,
        //        registerDto.Lifestyle_Condition_2,
        //        registerDto.Lifestyle_Condition_3,
        //        registerDto.Lifestyle_Condition_4,
        //        registerDto.Lifestyle_Condition_5
        //    );

        //    if (result)
        //    {
        //        _logger.LogInformation("User registered successfully: {Email}", registerDto.Email);
        //        return Ok(new { Message = "User registered successfully." });
        //    }

        //    _logger.LogError("User registration failed: {Email}", registerDto.Email);
        //    return StatusCode(500, new { Message = "User registration failed." });
        //}

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Login(LoginDto loginDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        _logger.LogWarning("Invalid login data received.");
        //        return BadRequest(ModelState);
        //    }

        //    var result = await _usersService.LoginUserAsync(loginDto.Email, loginDto.Password);

        //    if (result)
        //    {
        //        _logger.LogInformation("User login successful: {Email}", loginDto.Email);
        //        return Ok(new { Message = "Login successful." });
        //    }

        //    _logger.LogWarning("User login failed: {Email}", loginDto.Email);
        //    return Unauthorized(new { Message = "Invalid email or password." });

        //}

        //[HttpGet("user/{email}")]
        //public async Task<IActionResult> GetUserByEmail(string email)
        //{
        //    var user = await _usersService.GetUserByEmailAsync(email);

        //    if (user == null)
        //    {
        //        _logger.LogWarning("User not found: {Email}", email);
        //        return NotFound(new { Message = "User not found." });
        //    }

        //    _logger.LogInformation("User retrieved: {Email}", email);
        //    return Ok(user);
        //}


        //[HttpGet("user-details/{email}")]
        //public async Task<IActionResult> GetUserAndIdentityDetails(string email)
        //{
        //    var (user, identityUser) = await _usersService.GetUserAndIdentityAsync(email);

        //    if (user == null || identityUser == null)
        //    {
        //        _logger.LogWarning("User or Identity details not found: {Email}", email);
        //        return NotFound(new { Message = "User or Identity details not found." });
        //    }

        //    _logger.LogInformation("User and Identity details retrieved: {Email}", email);

        //    return Ok(new
        //    {
        //        User = user,
        //        IdentityUser = new
        //        {
        //            identityUser.Email,
        //            identityUser.UserName
        //        }
        //    });
        //}

           
    }
}
