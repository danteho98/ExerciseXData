using Microsoft.AspNetCore.Mvc;
using ExerciseXDataApi.Models.Data;

namespace ExerciseXDataApi.Controllers
{
    [Route("api/userAPI")] //The route here maintains across all users when accessed even if controller name changes in the future
    [ApiController]
    public class UserAPIController : Controller
    {
        /*
        Uri baseAddress = new Uri("https://localhost:44385/");
        private readonly HttpClient _client;

        public UserAPIController() {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        */

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult <IEnumerable <UserData>> GetUsers()
        {
            return Ok(UserData.usersList);

        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult <Users> GetUser(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var user = UserData.usersList.FirstOrDefault(u => u.U_Id == id);
            if (user == null) 
            {

                return NotFound();

            }
            return Ok(user);
        }
            
    }
}

