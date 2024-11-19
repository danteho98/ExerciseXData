//using ExerciseXDataLibrary.DataTransferObject;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace ExerciseXData.Controllers
//{
//    [Authorize (Roles = "User,Admin")]
//    public class UsersController : Controller
//    {

//        [HttpGet]
//        [Authorize(Roles = "NormalUser")]
//        public IActionResult UserDashboard()
//        {
//            if (User.Identity.IsAuthenticated)
//            {
//                var model = new UserDashboardDto
//                {
//                    Username = User.Identity.Name  // Assuming the user is logged in
//                };

//                return View(model);
//            }
//            else
//            {
//                return RedirectToAction("Login");
//            }

//            //return View();
//        }


//    }
//}//using ExerciseXDataLibrary.DataTransferObject;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace ExerciseXData.Controllers
//{
//    [Authorize (Roles = "User,Admin")]
//    public class UsersController : Controller
//    {

//        [HttpGet]
//        [Authorize(Roles = "NormalUser")]
//        public IActionResult UserDashboard()
//        {
//            if (User.Identity.IsAuthenticated)
//            {
//                var model = new UserDashboardDto
//                {
//                    Username = User.Identity.Name  // Assuming the user is logged in
//                };

//                return View(model);
//            }
//            else
//            {
//                return RedirectToAction("Login");
//            }

//            //return View();
//        }


//    }
//}
