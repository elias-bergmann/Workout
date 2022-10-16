using Microsoft.AspNetCore.Mvc;
using Work0ut.Model;
using Work0ut.Service;
using Work0ut.Utils;

namespace Work0ut.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExerciceController : ControllerBase
    {
        private readonly DatabaseConnectionService _databaseConnectionService;

        public ExerciceController(DatabaseConnectionService booksService) => _databaseConnectionService = booksService;

        [HttpGet]
        public async Task<List<Exercice>> Get() => await _databaseConnectionService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Exercice>> Get(string id)
        {
            var exercice = await _databaseConnectionService.GetAsync(id);

            if (exercice is null)
            {
                return NotFound();
            }

            return exercice;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Exercice newExercice)
        {
            await _databaseConnectionService.CreateAsync(newExercice);

            return CreatedAtAction(nameof(Get), new { id = newExercice.Id }, newExercice);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Exercice updatedExercice)
        {
            var exercice = await _databaseConnectionService.GetAsync(id);

            if (exercice is null)
            {
                return NotFound();
            }

            updatedExercice.Id = exercice.Id;

            await _databaseConnectionService.UpdateAsync(id, updatedExercice);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var exercice = await _databaseConnectionService.GetAsync(id);

            if (exercice is null)
            {
                return NotFound();
            }

            await _databaseConnectionService.RemoveAsync(id);

            return NoContent();
        }
    }
}