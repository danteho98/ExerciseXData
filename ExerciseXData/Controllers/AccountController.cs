using Microsoft.AspNetCore.Mvc;

using ExerciseXDataLibrary.Services;
using ExerciseXData_UserLibrary.DataTransferObject;

namespace ExerciseXWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UsersService _usersService;
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

       
        
    }
}
