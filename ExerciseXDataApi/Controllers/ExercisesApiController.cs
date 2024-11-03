using ExerciseXData.Models;
using ExerciseXData.Services;
using ExerciseXDataLibrary.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseXDataApi.Controllers
{
    [Route("api/exercises")]
    [ApiController]
    public class ExercisesApiController : Controller
    {
        private readonly ExercisesRepository _exerciseRepository;

        public ExercisesApiController(ExercisesRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        // Get all exercises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExercisesModel>>> GetExercises()
        {
            var exercises = await _exerciseRepository.GetAllExercisesAsync();
            return Ok(exercises);
        }

        // Get a single exercise by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<ExercisesModel>> GetExercise(int id)
        {
            var exercise = await _exerciseRepository.GetExerciseByIdAsync(id);
            if (exercise == null)
            {
                return NotFound();
            }
            return Ok(exercise);
        }

        // Create a new exercise
        [HttpPost]
        public async Task<ActionResult> CreateExercise([FromBody] ExercisesModel exercise)
        {
            await _exerciseRepository.AddExerciseAsync(exercise);
            return CreatedAtAction(nameof(GetExercise), new { id = exercise.E_Id }, exercise);
        }

        // Update an existing exercise
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExercise(int id, [FromBody] ExercisesModel exercise)
        {
            if (id != exercise.E_Id)
            {
                return BadRequest();
            }
            var result = await _exerciseRepository.UpdateExerciseAsync(id, exercise);

            if (!result)
            {
                return NotFound(); // Handle the case where the exercise is not found
            }

            return NoContent();
        }

        // Delete an exercise
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExercise(int id)
        {
            await _exerciseRepository.DeleteExerciseAsync(id);
            return NoContent();
        }
    }
}