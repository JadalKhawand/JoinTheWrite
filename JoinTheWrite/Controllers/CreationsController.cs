using JoinTheWrite.Models;
using JoinTheWrite.Models.Dto;
using JoinTheWrite.Services.WritingsService.CreationServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JoinTheWrite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreationsController : ControllerBase
    {
        private readonly ICreationService _creationService;

        public CreationsController(ICreationService creationService)
        {
            _creationService = creationService;
        }

        // GET: api/creations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Creation>>> GetAllCreations()
        {
            var creations = await _creationService.GetAllCreationsAsync();
            return Ok(creations);
        }

        // GET: api/creations/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Creation>> GetCreationById(Guid id)
        {
            var creation = await _creationService.GetCreationByIdAsync(id);

            if (creation == null)
            {
                return NotFound();
            }

            return Ok(creation);
        }

        // POST: api/creations
        [HttpPost]
        public async Task<ActionResult<Creation>> CreateCreation([FromBody] CreationDto creation)
        {
            if (creation == null)
            {
                return BadRequest();
            }

            var createdCreation = await _creationService.CreateCreationAsync(creation);

            // You can return 201 Created status with the location of the newly created resource
            return CreatedAtAction(nameof(GetCreationById), new { id = createdCreation.CreationId }, createdCreation);
        }

        // PUT: api/creations/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<Creation>> UpdateCreation(Guid id, [FromBody] CreationDto creation)
        {
            if (creation == null)
            {
                return BadRequest("Creation data is null.");
            }

            // Pass the 'id' directly into the service for update
            var updatedCreation = await _creationService.UpdateCreationAsync(id, creation);
            if (updatedCreation == null)
            {
                return NotFound();
            }

            return Ok(updatedCreation);
        }


        // DELETE: api/creations/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCreation(Guid id)
        {
            var deleted = await _creationService.DeleteCreationAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent(); // 204 No Content response
        }

        // GET: api/creations/user/{userId}
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<Creation>>> GetCreationsByUserId(Guid userId)
        {
            var creations = await _creationService.GetCreationsByUserIdAsync(userId);
            if (creations == null || creations.Count == 0)
            {
                return NotFound();
            }

            return Ok(creations);
        }
    }
}

