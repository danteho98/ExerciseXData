//using ExerciseXData.Data;
//using ExerciseXData.Interfaces;
//using ExerciseXData.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace foodXData.Controllers
//{
//    public class FoodController : Controller
//    {
//        private readonly IFoodService _service;

//        public FoodController(IFoodService service)
//        {
//            _service = service;
//        }

//        public async Task<IActionResult> Index()
//        {
//            var data = await _service.GetAllAsync();
//            return View(data);
//        }

//        public IActionResult Create()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> Create(
//            [Bind("F_Name, F_Calories, F_Modified_Date")] Food food)
//        {
//            if (!ModelState.IsValid)
//            {
//                return View(food);
//            }

//            await _service.AddAsync(food);
//            return RedirectToAction(nameof(Index));
//        }

//        public async Task<IActionResult> Details(int id)
//        {
//            var foodDetails = await _service.GetByIdAsync(id);

//            if (foodDetails == null) return View("Empty");
//            return View(foodDetails);
//        }

//        public IActionResult Edit()
//        {
//            return View();
//        }

//        public IActionResult Delete()
//        {
//            return View();
//        }

//        public IActionResult Statistics()
//        {
//            return View();
//        }
//    }
//}