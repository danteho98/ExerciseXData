/*
 using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ExerciseXData.Controllers
{
    public class UsersController : Controller
    {
        //public readonly User _context;
        public IActionResult Details()
        {
            return View();
        }
        public IActionResult Update()
        {
            return View();
        }

        public IActionResult PersonalStats()
        {
            //var orderCounts = _context.Users
            //    .GroupBy(o => o.OrderDate.Date)
            //    .Select(g => new OrderCountPerDay
            //    {
            //        Day = g.Key,
            //        Count = g.Count()
            //    })
            //    .OrderBy(o => o.Day)
            //    .ToList();

            //ViewBag.Labels = JsonConvert.SerializeObject(orderCounts.Select(o => o.Day.ToShortDateString()));
            //ViewBag.Data = JsonConvert.SerializeObject(orderCounts.Select(o => o.Count));

            return View();
        }

    }
}
*/