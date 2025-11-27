using JobPositionsApi.Models;
using JobPositionsApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JobPositionsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobPositionsController : ControllerBase
    {
        private readonly IJobPositionRepository _repo;
        public JobPositionsController(IJobPositionRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _repo.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}", Name = "GetJob")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _repo.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] JobPosition job)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var newId = await _repo.CreateAsync(job);
            job.Id = newId;
            return CreatedAtRoute("GetJob", new { id = newId }, job);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] JobPosition job)
        {
            if (id != job.Id) return BadRequest("ID mismatch");
            var exists = await _repo.GetByIdAsync(id);
            if (exists == null) return NotFound();
            var updated = await _repo.UpdateAsync(job);
            if (!updated) return StatusCode(500, "Failed to update the record.");
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var exists = await _repo.GetByIdAsync(id);
            if (exists == null) return NotFound();
            var deleted = await _repo.DeleteAsync(id);
            if (!deleted) return StatusCode(500, "Failed to delete.");
            return NoContent();
        }
    }
}
