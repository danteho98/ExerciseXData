using Microsoft.AspNetCore.Mvc;
using ExerciseXData.Models;

namespace ExerciseXDataApi.Controllers
{
    [Route("api/userAPI")] //The route here maintains across all users when accessed even if controller name changes in the future
    [ApiController]
    public class UsersApiController : Controller
    {
        /*
        Uri baseAddress = new Uri("https://localhost:44385/");
        private readonly HttpClient _client;

        public UserAPIController() {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        */

        //[HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]

    }
}

